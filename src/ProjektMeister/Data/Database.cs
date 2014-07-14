using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Views;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Entities.FieldInfos;
using DatenMeister.Logic;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using ProjektMeister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektMeister.Data
{
    /// <summary>
    /// Stores the datenmeister instance and all its properties
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Stores the uri for new instances
        /// </summary>
        public const string uri = "datenmeister:///projektmeister/data";

        /// <summary>
        /// Stores the uri for the types and other general information
        /// </summary>
        private const string typeUri = "datenmeister:///projektmeister/types";

        /// <summary>
        /// Stores the uri for the views
        /// </summary>
        private const string viewUri = "datenmeister:///projektmeister/views";

        /// <summary>
        /// Stores the datenmeister pool
        /// </summary>
        private DatenMeisterPool pool;

        /// <summary>
        /// Stores the xmlsettings being used for 
        /// </summary>
        private XmlSettings xmlSettings;

        /// <summary>
        /// The extent, which is used by the ProjektMeister
        /// </summary>
        private IURIExtent projectExtent;

        /// <summary>
        /// Gets or sets the type extent
        /// </summary>
        public IURIExtent TypeExtent
        {
            get;
            set;
        }

        public IURIExtent ProjectExtent
        {
            get { return this.projectExtent; }
        }

        public DotNetExtent ViewExtent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the settings of the xml file
        /// </summary>
        public XmlSettings Settings
        {
            get { return this.xmlSettings; }
        }

        public DatenMeisterPool Pool
        {
            get { return this.pool; }
        }

        /// <summary>
        /// Initializes a new instance of the the database
        /// </summary>
        public void Init()
        {
            this.pool = new DatenMeisterPool();
            this.pool.DoDefaultBinding();

            // Adds the extent for the extents
            var poolExtent = new DatenMeisterPoolExtent(this.pool);
            this.pool.Add(poolExtent, null, DatenMeisterPoolExtent.DefaultName);

            this.TypeExtent = ProjektMeister.Data.Entities.AsObject.Types.Init();
            this.pool.Add(this.TypeExtent, null, "ProjektMeister Types"); 
            this.InitDatabase();
            this.InitViews();
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        private void InitDatabase()
        {
            var dataDocument = new XDocument();
            var xmlProjectExtent = new XmlExtent(dataDocument, uri);
            this.xmlSettings = new XmlSettings();
            this.xmlSettings.SkipRootNode = true;
            this.xmlSettings.Mapping.Add(
                "person", 
                ProjektMeister.Data.Entities.AsObject.Types.Person, 
                (x) => x.Elements().Elements("persons").First());
            this.xmlSettings.Mapping.Add(
                "task",
                ProjektMeister.Data.Entities.AsObject.Types.Task, 
                (x) => x.Elements().Elements("tasks").First());

            xmlProjectExtent.Settings = xmlSettings;

            this.pool.Add(xmlProjectExtent, null, ExtentNames.DataExtent);

            xmlProjectExtent.Settings.InitDatabaseFunction = (x) =>
                {
                    FillEmptyDocument(x);
                };

            xmlProjectExtent.Settings.InitDatabaseFunction(dataDocument);

            this.projectExtent = xmlProjectExtent;
        }

        /// <summary>
        /// Fills an empty document 
        /// </summary>
        /// <param name="document">Document being filled</param>
        public static void FillEmptyDocument(XDocument document)
        {
            var xmlPersons = new XElement("persons");
            var xmlTasks = new XElement("tasks");
            if (document.Root == null)
            {
                document.Add(new XElement("data"));
            }

            document.Root.Add(xmlPersons);
            document.Root.Add(xmlTasks);
        }

        private void InitViews()
        {
            this.ViewExtent = new DotNetExtent(viewUri);
            DatenMeister.Entities.AsObject.FieldInfo.Types.AssignTypeMapping(this.ViewExtent);

            ////////////////////////////////////////////
            // List view for persons
            var personTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.PersonTable = new DotNetObject(this.ViewExtent, personTableView);
            this.ViewExtent.Elements().add(Views.PersonTable);
            var asObjectPersons = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.PersonTable);

            var personColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"));
            asObjectPersons.setFieldInfos(personColumns);
            asObjectPersons.setName("Persons");
            asObjectPersons.setExtentUri(uri + "?type=Person");
            asObjectPersons.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Person);

            // Detail view for persons
            var personDetailView = new DatenMeister.Entities.FieldInfos.FormView();
            Views.PersonDetail = new DotNetObject(this.ViewExtent, personDetailView);
            this.ViewExtent.Elements().add(Views.PersonDetail);
            Views.PersonDetail.set("name", "Person (Detail)");

            var personDetailColumns = new DotNetSequence(
                new TextField("First Name", "firstname"),
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"),
                new TextField("Comment", "comment")
                {
                    isMultiline = true
                });
            Views.PersonDetail.set("fieldInfos", personDetailColumns);

            ////////////////////////////////////////////
            // List view for tasks
            var taskTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.TaskTable = new DotNetObject(this.ViewExtent, taskTableView);
            this.ViewExtent.Elements().add(Views.TaskTable);
            var asObjectTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.TaskTable);

            var taskColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("Start", "startdate")
                {
                    isDateTime = true
                },
                new TextField("Ende", "enddate")
                {
                    isDateTime = true
                },
                new TextField("Finished", "finished"),
                new TextField("Assigned", "assignedPerson"),
                new TextField("Predecessors", "predecessors"));
            asObjectTasks.setFieldInfos(taskColumns);
            asObjectTasks.setName("Tasks");
            asObjectTasks.setExtentUri(uri + "?type=Task");
            asObjectTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);

            // Detail view for persons
            var taskDetailView = new DatenMeister.Entities.FieldInfos.FormView();
            Views.TaskDetail = new DotNetObject(this.ViewExtent, taskDetailView);
            Views.TaskDetail.set("name", "Person (Detail)");
            this.ViewExtent.Elements().add(Views.TaskDetail);

            var taskDetailColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new DatePicker("Start", "startdate"),
                new DatePicker("Ende", "enddate"),
                new Checkbox("Finished", "finished"),
                new ReferenceByRef("Assigned", "assignedPerson", uri + "?type=Person", "name"),
                new MultiReferenceField("Predecessors", "predecessors", uri + "?type=Task", "name"));
            Views.TaskDetail.set("fieldInfos", taskDetailColumns);

            // Adds the extent of views to the pool
            this.pool.Add(this.ViewExtent, null, "ProjektMeister Views");
        }

        public static class Views
        {
            public static IObject PersonTable
            {
                get;
                internal set;
            }

            public static IObject TaskTable
            {
                get;
                internal set;
            }

            public static IObject PersonDetail
            {
                get;
                internal set;
            }

            public static IObject TaskDetail
            {
                get;
                internal set;
            }
        }

        /// <summary>
        /// Replaces the data database
        /// </summary>
        /// <param name="extent">Xml Extent being stored</param>
        internal void ReplaceDatabase(XmlExtent extent)
        {
            extent.Settings = this.xmlSettings;
            this.projectExtent = extent;

            foreach (var mapping in this.xmlSettings.Mapping.GetAll())
            {
                if (mapping.RetrieveRootNode(extent.XmlDocument) == null)
                {
                    throw new InvalidOperationException("Given extent is not compatible to ProjektMeister");
                }
            }
        }
    }
}
