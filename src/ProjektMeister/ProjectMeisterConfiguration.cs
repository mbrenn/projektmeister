using BurnSystems.Logging;
using BurnSystems.ObjectActivation;
using BurnSystems.Test;
using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Logic;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
using ProjektMeister.Data;
using System;
using System.Linq;
using System.Xml.Linq;

namespace ProjektMeister 
{
    public class ProjectMeisterConfiguration : BaseDatenMeisterSettings, IDatenMeisterSettings
    {
        #region Uri

        /// <summary>
        /// Stores the uri for new instances
        /// </summary>
        public const string DataUri = "datenmeister:///projektmeister/data";

        /// <summary>
        /// Stores the uri for the types and other general information
        /// </summary>
        public const string TypeUri = "datenmeister:///projektmeister/types";

        /// <summary>
        /// Stores the uri for the views
        /// </summary>
        public const string ViewUri = "datenmeister:///projektmeister/views";

        #endregion

        /// <summary>
        /// Stores the logger
        /// </summary>
        private ILog logger = new ClassLogger(typeof(ProjectMeisterConfiguration));

        /// <summary>
        /// Stores the meta types
        /// </summary>
        private DotNetExtent metaTypes;

        /// <summary>
        /// Performs the full initialization at application start. 
        /// This method is just called once
        /// </summary>
        public override void InitializeForBootUp(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeForBootUp");

            this.ApplicationName = "ProjektMeister";
            this.WindowTitle = "Depon.Net - ProjektMeister";

            // Initializes the types. This is done once per startup
            this.metaTypes = new DotNetExtent("datenmeister:///datenmeister/metatypes/");
            DatenMeister.Entities.AsObject.Uml.Types.Init(this.metaTypes);
            DatenMeister.Entities.AsObject.FieldInfo.Types.Init(this.metaTypes);
            DatenMeister.Entities.AsObject.DM.Types.Init(this.metaTypes);
        }

        public override void InitializeViewSet(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeViewSet");
            var pool = PoolResolver.GetDefaultPool();

            // Initializes the database itself
            this.metaTypes.ReleaseFromPool();

            pool.Add(this.metaTypes, null, "MetaTypes", ExtentType.MetaType);

            // Defines the types of Projekkt Meister
            var typeExtent = ProjektMeister.Data.Entities.AsObject.Types.Init();
            pool.Add(typeExtent, core.GetApplicationStoragePathFor("types"), "ProjektMeister Types", ExtentType.Type);
            Database.InitViews(pool);

            // Initialize the viewManager
            var viewExtent = PoolResolver.GetDefaultPool().GetExtent(ExtentType.View).First();
            var viewManager = new DefaultViewManager(viewExtent);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Person,
                    Database.Views.PersonDetail, true);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Task,
                    Database.Views.TaskDetail, true);
            viewManager.DoAutogenerateForm = true;

            Injection.Application.Bind<IViewManager>().ToConstant(viewManager);

            // Initializes the data 
            var dataDocument = new XDocument(
                new XElement("data",
                    new XElement("persons"),
                    new XElement("tasks")));

            // Creates and adds the empty project
            var xmlProjectExtent = new XmlExtent(dataDocument, DataUri);
            pool.Add(xmlProjectExtent, null, ExtentNames.DataExtent, ExtentType.Data);

            // Adds the query extent for the OpenTasks
            pool.Add(
                new ReflectiveExtent(
                    () =>
                        PoolResolver.GetDefaultPool()
                        .GetExtent(ExtentType.Data).First()
                        .Elements()
                        .FilterByProperty("finished", false),
                    DataUri + "/OpenTasks"),
                null,
                "Open Tasks",
                ExtentType.Query);
        }

        public override void InitializeFromScratch(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeFromScratch");

            this.InitializeAfterLoading(core);
        }

        public override void InitializeAfterLoading(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: Initialize After Loading");
            var pool = PoolResolver.GetDefaultPool();
            var dataExtent = pool.GetExtent(ExtentType.Data).First() as XmlExtent;
            Ensure.That(dataExtent != null, "DataExtent is not XmlExtent");

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
            dataExtent.Settings = xmlSettings;
        } 

        /// <summary>
        /// Demo data for application start
        /// </summary>
        /// <param name="core">Core to be used</param>
        public override void InitializeForExampleData(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeForExampleData");

            var viewExtent = PoolResolver.GetDefaultPool().GetExtent(ExtentType.View).First();
            var projectExtent = PoolResolver.GetDefaultPool().GetExtent(ExtentType.Data).First();

            for (var n = 0; n < 1; n++)
            {
                // Create some persons, just for test
                var factory = Factory.GetFor(projectExtent);
                var person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Person);
                person.set("firstname", "Martin");
                person.set("name", "Brenn");
                person.set("email", "brenn@depon.net");
                person.set("phone", "0151/560");
                person.set("title", "Project Lead");

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Person);
                person.set("firstname", "Martina");
                person.set("name", "Brenn");
                person.set("email", "brenna@depon.net");
                person.set("phone", "0151/650");
                person.set("title", "Project Support");

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My First Task");
                person.set("startdate", DateTime.Now);
                person.set("enddate", DateTime.Now.AddMonths(1));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Second Task");
                person.set("startdate", DateTime.Now.AddMonths(1));
                person.set("enddate", DateTime.Now.AddMonths(2));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Third Task");
                person.set("startdate", DateTime.Now.AddMonths(3));
                person.set("enddate", DateTime.Now.AddMonths(4));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Fourth Task");
                person.set("startdate", DateTime.Now.AddMonths(4));
                person.set("enddate", DateTime.Now.AddMonths(5));
                person.set("finished", false);
            }

            // Reset dirty flag
            projectExtent.IsDirty = false;
        }

        /// <summary>
        /// Stores the view set
        /// </summary>
        /// <param name="core">Core to be used</param>
        public override void StoreViewSet(ApplicationCore core)
        {
            if (core != null)
            {
                core.SaveExtentByUri("datenmeister:///projektmeister/types");
                core.Dispose();
            }
        }
    }
}
