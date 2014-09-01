using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Views;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Entities.FieldInfos;
using DatenMeister.Logic;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
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
        /// Initializes the database
        /// </summary>
        private static XmlExtent AddDataExtent()
        {
            var pool = PoolResolver.GetDefaultPool();

            var dataDocument = new XDocument();
            var xmlProjectExtent = new XmlExtent(dataDocument, ProjectMeisterConfiguration.DataUri);
            var xmlSettings = new XmlSettings();
            xmlSettings.SkipRootNode = true;
            xmlSettings.Mapping.Add(
                "person", 
                ProjektMeister.Data.Entities.AsObject.Types.Person, 
                (x) => x.Elements().Elements("persons").First());
            xmlSettings.Mapping.Add(
                "task",
                ProjektMeister.Data.Entities.AsObject.Types.Task, 
                (x) => x.Elements().Elements("tasks").First());

            xmlProjectExtent.Settings = xmlSettings;

            pool.Add(xmlProjectExtent, null, ExtentNames.DataExtent, ExtentType.Data);

            return xmlProjectExtent;
        }

        public static void InitViews(IPool pool)
        {
            var viewExtent = new XmlExtent(new XDocument(new XElement("views")), ProjectMeisterConfiguration.ViewUri);

            // Adds the extent of views to the pool
            pool.Add(viewExtent, null, "ProjektMeister Views", ExtentType.View);

            // Creates the factory
            var factory = Factory.GetFor(viewExtent);

            ////////////////////////////////////////////
            // List view for persons
            Views.PersonTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.PersonTable);
            var asObjectPersons = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.PersonTable);

            var personColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("First Name", "firstname"),
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"));
            asObjectPersons.setFieldInfos(personColumns);
            asObjectPersons.setName("Persons");
            asObjectPersons.setExtentUri(ProjectMeisterConfiguration.DataUri + "?type=Person");
            asObjectPersons.setAllowNew(true);
            asObjectPersons.setAllowEdit(true);
            asObjectPersons.setAllowDelete(true);
            asObjectPersons.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Person);

            // Detail view for persons
            var personDetailView = new DatenMeister.Entities.FieldInfos.FormView();
            Views.PersonDetail = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.FormView);
            viewExtent.Elements().add(Views.PersonDetail);
            Views.PersonDetail.set("name", "Person (Detail)");

            var personDetailColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
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
            Views.TaskTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.TaskTable);
            var asObjectTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.TaskTable);

            var taskColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("Name", "name")
                {
                    columnWidth = 200
                },
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
                new TextField("Predecessors", "predecessors")
                {
                    columnWidth = 200
                });
            asObjectTasks.setFieldInfos(taskColumns);
            asObjectTasks.setName("Tasks");
            asObjectTasks.setExtentUri(ProjectMeisterConfiguration.DataUri + "?type=Task");
            asObjectTasks.setAllowNew(true);
            asObjectTasks.setAllowEdit(true);
            asObjectTasks.setAllowDelete(true);
            asObjectTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);

            // Detail view for persons
            Views.TaskDetail = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.FormView);
            Views.TaskDetail.set("name", "Person (Detail)");
            viewExtent.Elements().add(Views.TaskDetail);

            var taskDetailColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("Name", "name"),
                new DatePicker("Start", "startdate"),
                new DatePicker("Ende", "enddate"),
                new Checkbox("Finished", "finished"),
                new ReferenceByRef("Assigned", "assignedPerson", ProjectMeisterConfiguration.DataUri + "?type=Person", "name"),
                new MultiReferenceField("Predecessors", "predecessors", ProjectMeisterConfiguration.DataUri + "?type=Task", "name"),
                new TextField("Comment", "comment")
                {
                    isMultiline = true
                });
            Views.TaskDetail.set("fieldInfos", taskDetailColumns);

            ////////////////////////////////////////////
            // List view for all the open tasks
            Views.OpenTaskTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.OpenTaskTable);
            asObjectTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.OpenTaskTable);

            asObjectTasks.setFieldInfos(taskColumns);
            asObjectTasks.setName("Open Tasks");
            asObjectTasks.setExtentUri(ProjectMeisterConfiguration.DataUri + "/OpenTasks");
            asObjectTasks.setAllowNew(true);
            asObjectTasks.setAllowEdit(true);
            asObjectTasks.setAllowDelete(true);
            asObjectTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);
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

            public static IObject OpenTaskTable
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
    }
}
