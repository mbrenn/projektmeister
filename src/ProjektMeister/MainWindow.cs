using BurnSystems.ObjectActivation;
using DatenMeister;
using DatenMeister.AddOns.Export.Excel;
using DatenMeister.AddOns.Export.Report.Simple;
using DatenMeister.AddOns.Views;
using DatenMeister.DataProvider;
using DatenMeister.Logic;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
using DatenMeister.WPF.Helper;
using DatenMeister.WPF.Modules.RecentFiles;
using DatenMeister.WPF.Windows;
using ProjektMeister.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ProjektMeister 
{
    public class MainWindow : BaseDatenMeisterSettings, IDatenMeisterSettings
    {
        /// <summary>
        /// Stores the applicatin core
        /// </summary>
        private ApplicationCore core;

        /// <summary>
        /// Starts the ProjektMeister
        /// </summary>
        public void Start()
        {
            this.ApplicationName = "ProjektMeister";
            this.WindowTitle = "Depon.Net - ProjektMeister";

            // Initializes the types
            var umlTypes = DatenMeister.Entities.AsObject.Uml.Types.Init();
            var fieldInfoTypes = DatenMeister.Entities.AsObject.FieldInfo.Types.Init();
            var dmTypes = DatenMeister.Entities.AsObject.DM.Types.Init();

            // Start the application
            this.Pool = DatenMeisterPool.Create();
            this.core = new ApplicationCore(this);
            var database = this.InitializeDatabase();
            database.Pool.Add(umlTypes, null, "UML Types");
            database.Pool.Add(fieldInfoTypes, null, "FieldInfos Types");
            database.Pool.Add(dmTypes, null, "DatenMeister Types");
            var wnd = WindowFactory.CreateWindow(this.core);

            // Other menu helper
            RecentFileIntegration.AddSupport(wnd);
            MenuHelper.AddExtentView(wnd, database.ViewExtent);

            // Exports the entry to an excel item
            ExcelExportGui.AddMenu(wnd, () => this.ProjectExtent);
            TypeManager.Integrate(wnd);
            SimpleReportGui.Integrate(wnd);
        }

        public void Stop()
        {
            if (this.core != null)
            {
                this.core.SaveExtentByUri("datenmeister:///projektmeister/types");
                this.core.Dispose();
            }
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        /// <param name="wnd">Window to be used</param>
        private Database InitializeDatabase()
        {
            var database = new Database();

            // Initializes the database itself
            database.Init(this.core, this.Pool);
            this.ProjectExtent = database.ProjectExtent;
            this.ExtentSettings = database.Settings;
            this.ViewExtent = database.ViewExtent; // Here, the views are initialized
            this.TypeExtent = database.TypeExtent;

            for (var n = 0; n < 1; n++)
            {
                // Create some persons, just for test
                var factory = Factory.GetFor(database.ProjectExtent);
                var person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Person);
                person.set("name", "Martin Brenn");
                person.set("email", "brenn@depon.net");
                person.set("phone", "0151/560");
                person.set("title", "Project Lead");

                person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Person);
                person.set("name", "Martina Brenn");
                person.set("email", "brenna@depon.net");
                person.set("phone", "0151/650");
                person.set("title", "Project Support");

                person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My First Task");
                person.set("startdate", DateTime.Now);
                person.set("enddate", DateTime.Now.AddMonths(1));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Second Task");
                person.set("startdate", DateTime.Now.AddMonths(1));
                person.set("enddate", DateTime.Now.AddMonths(2));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Third Task");
                person.set("startdate", DateTime.Now.AddMonths(3));
                person.set("enddate", DateTime.Now.AddMonths(4));
                person.set("finished", false);

                person = factory.CreateInExtent(
                    database.ProjectExtent,
                    ProjektMeister.Data.Entities.AsObject.Types.Task);
                person.set("name", "My Fourth Task");
                person.set("startdate", DateTime.Now.AddMonths(4));
                person.set("enddate", DateTime.Now.AddMonths(5));
                person.set("finished", false);
            }

            // Reset dirty flag
            database.ProjectExtent.IsDirty = false;

            // Initialize the activation container
            var viewManager = new DefaultViewManager(database.ViewExtent);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Person,
                    Database.Views.PersonDetail, true);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Task,
                    Database.Views.TaskDetail, true);
            viewManager.DoAutogenerateForm = true;

            Global.Application.Bind<IViewManager>().ToConstant(viewManager);

            return database;
        }

        /// <summary>
        /// Creates an empty document
        /// </summary>
        /// <returns>Document, being empty</returns>
        public override XDocument CreateEmpty()
        {
            var document = new XDocument();
            Database.FillEmptyDocument(document);
            return document;
        }
    }
}
