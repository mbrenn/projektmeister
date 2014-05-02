﻿using DatenMeister;
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
    public class MainWindow : BaseDatenMeisterSeetings, IDatenMeisterSettings
    {
        public void Start()
        {
            var wnd = new DatenMeisterWindow();
            this.InitializeDatabase(wnd);
            wnd.Show();
        }

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
            wnd.Settings = this;

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

            // Initializes the views
            wnd.AddExtentView("Persons",
                new AddExtentParameters()
                {
                    ExtentFactory = (x) => x.FilterByType(Database.Types.Person),
                    TableViewInfo = Database.Views.PersonTable,
                    DetailViewInfo = Database.Views.PersonDetail,
                    ElementFactory = () => wnd.Settings.ProjectExtent.CreateObject(Database.Types.Person)
                });

            wnd.AddExtentView("Tasks",
                new AddExtentParameters()
                {
                    ExtentFactory = (x) => x.FilterByType(Database.Types.Task),
                    TableViewInfo = Database.Views.TaskTable,
                    DetailViewInfo = Database.Views.TaskDetail,
                    ElementFactory = () => wnd.Settings.ProjectExtent.CreateObject(Database.Types.Task)
                });

            // Reset dirty flag
            database.ProjectExtent.IsDirty = false;
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
