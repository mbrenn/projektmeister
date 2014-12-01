using BurnSystems.Logging;
using BurnSystems.ObjectActivation;
using BurnSystems.Test;
using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Logic;
using DatenMeister.Logic.TypeResolver;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
using Ninject;
using ProjektMeister.Data;
using ProjektMeister.Data.Entities.AsObject;
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
        /// Performs the full initialization at application start. 
        /// This method is just called once
        /// </summary>
        public override void InitializeForBootUp(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeForBootUp");

            this.ApplicationName = "ProjektMeister";
            this.WindowTitle = "Depon.Net - ProjektMeister";
        }

        public override void InitializeViewSet(ApplicationCore core)
        {         
            logger.Notify("ProjectMeisterConfiguration: InitializeViewSet");         
        }

        public override void FinalizeExtents(ApplicationCore core, bool wasLoading)
        {
            var workBenchManager = WorkbenchManager.Get();
            logger.Notify("ProjectMeisterConfiguration: FinalizeExtents");           

            var pool = PoolResolver.GetDefaultPool();
            
            ////////////////////////////////////////////////
            // Checks and or defines the types
            var storagePath = core.GetApplicationStoragePathFor("Types");
            var typeExtent = pool.GetExtents(ExtentType.Type).FirstOrDefault();
            if (typeExtent == null)
            {
                var xmlExtent = new XmlExtent(
                    new XDocument(new XElement("Types")),
                    ProjektMeister.Data.Entities.AsObject.Types.DefaultExtentUri,
                    XmlSettings.Empty);
                ProjektMeister.Data.Entities.AsObject.Types.Init(xmlExtent);
                workBenchManager.AddExtent(
                    xmlExtent,
                    new ExtentParam("Types", ExtentType.Type, storagePath));
            }
            else
            {
                // Successful loading, now assign the types
                Types.Person = typeExtent.Elements().FilterByProperty("name", "Person").First().AsIObject();
                Types.Task = typeExtent.Elements().FilterByProperty("name", "Task").First().AsIObject();
            }

            // Initializes the types. This is done once per startup
            var xmlSettings = new XmlSettings();
            xmlSettings.OnlyUseAssignedNodes = true;
            xmlSettings.Mapping.Add(
                "person",
                ProjektMeister.Data.Entities.AsObject.Types.Person,
                (x) => x.Elements().Elements("persons").First());
            xmlSettings.Mapping.Add(
                "task",
                ProjektMeister.Data.Entities.AsObject.Types.Task,
                (x) => x.Elements().Elements("tasks").First());

            /////////////////////////////////////////////
            // Checks whether the data was found
            var dataExtent = pool.GetExtents(ExtentType.Data).FirstOrDefault();
            if (dataExtent == null)
            {
                if (wasLoading)
                {
                    logger.Fail("No data extent was found, a new one will be created");
                }

                // Initializes the data
                var dataDocument = new XDocument(
                    new XElement("data",
                        new XElement("persons"),
                        new XElement("tasks")));

                // Creates and adds the empty project
                var xmlProjectExtent = new XmlExtent(dataDocument, DataUri);
                xmlProjectExtent.Settings = xmlSettings;
                workBenchManager.AddExtent(
                    xmlProjectExtent,
                    new ExtentParam(ExtentNames.DataExtent, ExtentType.Data));
            }
            else
            {
                var xmlExtent = dataExtent as XmlExtent;
                Ensure.That(dataExtent != null, "DataExtent is not XmlExtent");

                xmlExtent.Settings = xmlSettings;
            }

            //////////////////////////////////////////////////////
            // Initialize views
            Database.InitViews(pool);

            // Adds the query extent for the OpenTasks        
            var openTaskExtent = new ReflectiveExtent(
                    () =>
                        PoolResolver.GetDefaultPool()
                            .GetExtents(ExtentType.Data).First()
                            .Elements()
                            .FilterByType(Types.Task)
                            .FilterByProperty("category", "Task")
                            .FilterByProperty("finished", false),
                    DataUri + "/OpenTasks");
            workBenchManager.AddExtent(
                openTaskExtent,
                new ExtentParam("Open Tasks", ExtentType.Query).AsPrepopulated());
            
            // Initialize the viewManager
            var viewExtent = PoolResolver.GetDefaultPool().GetExtents(ExtentType.View).First();
            var viewManager = new DefaultViewManager(viewExtent);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Person,
                    Database.Views.PersonDetail,
                    true);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Task,
                    Database.Views.TaskDetail,
                    true);
            viewManager.DoAutogenerateForm = true; // Allow the autogeneration of forms

            Injection.Application.Rebind<IViewManager>().ToConstant(viewManager);
        }

        /// <summary>
        /// Demo data for application start
        /// </summary>
        /// <param name="core">Core to be used</param>
        public override void InitializeForExampleData(ApplicationCore core)
        {
            logger.Notify("ProjectMeisterConfiguration: InitializeForExampleData");

            var viewExtent = PoolResolver.GetDefaultPool().GetExtents(ExtentType.View).First();
            var projectExtent = PoolResolver.GetDefaultPool().GetExtents(ExtentType.Data).First();

            for (var n = 0; n < 1; n++)
            {   
                // Create some persons, just for test
                var factory = Factory.GetFor(projectExtent);

                var realPerson = Person.createTyped(factory);
                realPerson.setFirstname("Martin");
                realPerson.setName("Brenn");
                realPerson.setEmail("brenn@depon.net");
                realPerson.setPhone("0151/560");
                realPerson.setTitle("Project Lead");
                projectExtent.Elements().add(realPerson.Value);

                var person = factory.CreateInExtent(
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
                person.set("category", "Task");
                person.set("startdate", DateTime.Now);
                person.set("enddate", DateTime.Now.AddMonths(-1));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Second Task");
                person.set("category", "Task");
                person.set("startdate", DateTime.Now.AddMonths(1));
                person.set("enddate", DateTime.Now.AddMonths(2));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Third Task");
                person.set("category", "Task");
                person.set("startdate", DateTime.Now.AddMonths(3));
                person.set("enddate", DateTime.Now.AddMonths(4));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    projectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "Final Delivery");
                person.set("category", "Milestone");
                person.set("startdate", DateTime.Now.AddMonths(5));
                person.set("enddate", DateTime.Now.AddMonths(5));
                person.set("finished", false);
            }

            // Reset dirty flag
            projectExtent.IsDirty = false;
        }

        /// <summary>
        /// Stores the workbench
        /// </summary>
        /// <param name="core">Core to be used</param>
        public override void StoreViewSet(ApplicationCore core)
        {
            if (core != null)
            {
                // Stores the type information 
                core.SaveExtentByUri(ProjektMeister.Data.Entities.AsObject.Types.DefaultExtentUri);
            }
        }
    }
}
