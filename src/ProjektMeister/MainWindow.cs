using BurnSystems.ObjectActivation;
using DatenMeister;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
using DatenMeister.WPF.Windows;
using ProjektMeister.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektMeister 
{
    public class MainWindow : BaseDatenMeisterSettings, IDatenMeisterSettings
    {
        /// <summary>
        /// Starts the ProjektMeister
        /// </summary>
        public void Start()
        {
            var wnd = new DatenMeisterWindow();
            this.InitializeDatabase(wnd);

            // Just sets the title and shows the Window
            wnd.SetTitle("Depon.Net ProjektMeister");
            wnd.Show();
            wnd.RefreshViews();
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        /// <param name="wnd">Window to be used</param>
        private void InitializeDatabase(IDatenMeisterWindow wnd)
        {
            var database = new Database();

            var umlTypes = DatenMeister.Entities.AsObject.Uml.Types.Init();
            var fieldInfoTypes = DatenMeister.Entities.AsObject.FieldInfo.Types.Init();

            // Initializes the database itself
            database.Init();
            this.Pool = database.Pool;
            this.ProjectExtent = database.ProjectExtent;
            this.ExtentSettings = database.Settings;
            this.ViewExtent = database.ViewExtent; // Here, the views are initialized
            wnd.Settings = this;

            for (var n = 0; n < 1; n++)
            {
                // Create some persons, just for test
                var person = database.ProjectExtent.CreateObject(Database.Types.Person);
                person.set("name", "Martin Brenn");
                person.set("email", "brenn@depon.net");
                person.set("phone", "0151/560");
                person.set("title", "Project Lead");

                person = database.ProjectExtent.CreateObject(Database.Types.Person);
                person.set("name", "Martina Brenn");
                person.set("email", "brenna@depon.net");
                person.set("phone", "0151/650");
                person.set("title", "Project Support");

                person = database.ProjectExtent.CreateObject(Database.Types.Task);
                person.set("name", "My First Task");
                person.set("startdate", DateTime.Now);
                person.set("enddate", DateTime.Now.AddYears(1));
                person.set("finished", false);
            }

            // Reset dirty flag
            database.ProjectExtent.IsDirty = false;

            // Initialize the activation container
            var viewManager = new DefaultViewManager();
            viewManager.Add(Database.Types.Person, Database.Views.PersonDetail, true);
            viewManager.Add(Database.Types.Task, Database.Views.TaskDetail, true);

            Global.Application.Bind<IViewManager>().ToConstant(viewManager);

            // Initializes the default resolver
            this.Pool.DoDefaultBinding();
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
