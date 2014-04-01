﻿using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Views;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Entities.FieldInfos;
using DatenMeister.Logic.Views;
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
        private const string uri = "datenmeister:///projektmeister/data";

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
        /// The extent, which is used by the ProjektMeister
        /// </summary>
        private IURIExtent projectExtent;

        /// <summary>
        /// The extent, which is used by the ProjektMeister
        /// </summary>
        private IURIExtent typeExtent;

        public IURIExtent ProjectExtent
        {
            get { return this.projectExtent; }
        }

        /// <summary>
        /// Initializes a new instance of the the database
        /// </summary>
        public void Init()
        {
            this.pool = new DatenMeisterPool();

            this.InitTypes();
            this.InitDatabase();
            this.InitViews();
        }

        private void InitDatabase()
        {
            var dataDocument = new XDocument(new XElement("data"));
            var projectExtent = new XmlExtent(dataDocument, uri);
            projectExtent.SkipRootNode = true;
            this.pool.Add(this.projectExtent, null, "ProjektMeister");

            var xmlPersons = new XElement("persons");
            var xmlTasks = new XElement("tasks");

            projectExtent.Mapping.Add("person", Types.Person, xmlPersons);
            projectExtent.Mapping.Add("task", Types.Task, xmlTasks);
            dataDocument.Root.Add(xmlPersons);
            dataDocument.Root.Add(xmlTasks);

            this.projectExtent = projectExtent;
        }

        private void InitTypes()
        {
            var typeDocument = new XDocument(new XElement("types"));
            this.typeExtent = new XmlExtent(typeDocument, typeUri);
            this.pool.Add(this.typeExtent, null, "ProjektMeister Types");

            // Creates the types
            Types.Person = typeExtent.CreateObject();
            var person = new DatenMeister.Entities.AsObject.Uml.Type(Types.Person);
            person.setName("Person");

            Types.Task = typeExtent.CreateObject();
            var task = new DatenMeister.Entities.AsObject.Uml.Type(Types.Task);
            task.setName("Task");
        }

        private void InitViews()
        {
            var viewExtent = new DotNetExtent(viewUri);
            DatenMeister.Entities.AsObject.FieldInfo.Types.AssignTypeMapping(viewExtent);

            ////////////////////////////////////////////
            // List view for persons
            var personTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.PersonTable = new DotNetObject(viewExtent, personTableView);
            viewExtent.Add(Views.PersonTable);

            var personColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"));
            Views.PersonTable.set("fieldInfos", personColumns);

            // Detail view for persons
            var personDetailView = new DatenMeister.Entities.FieldInfos.FormView();
            Views.PersonDetail = new DotNetObject(viewExtent, personDetailView);
            viewExtent.Add(Views.PersonTable);

            var personDetailColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"));
            Views.PersonDetail.set("fieldInfos", personDetailColumns);

            ////////////////////////////////////////////
            // List view for tasks
            var taskTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.TaskTable = new DotNetObject(viewExtent, taskTableView);
            viewExtent.Add(Views.TaskTable);

            var taskColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("Start", "startdate"),
                new TextField("Ende", "enddate"),
                new TextField("Finished", "bool"));
            Views.TaskTable.set("fieldInfos", taskColumns);

            // Detail view for persons
            var taskDetailView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.TaskDetail = new DotNetObject(viewExtent, taskDetailView);
            viewExtent.Add(Views.TaskDetail);

            var taskDetailColumns = new DotNetSequence(
                new TextField("Name", "name"),
                new TextField("Start", "startdate"),
                new TextField("Ende", "enddate"),
                new TextField("Finished", "bool"));
            Views.TaskDetail.set("fieldInfos", taskDetailColumns);

            this.pool.Add(viewExtent, null, "ProjektMeister Views");
        }

        /// <summary>
        /// Stores the types for persons and tasks
        /// </summary>
        public static class Types
        {
            public static IObject Person
            {
                get;
                internal set;
            }

            public static IObject Task
            {
                get;
                internal set;
            }
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
    }
}
