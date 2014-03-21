﻿using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Xml;
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

        /// <summary>
        /// Initializes a new instance of the the database
        /// </summary>
        public void Init()
        {
            this.pool = new DatenMeisterPool(); 
            
            this.InitDatabase();
            this.InitTypes();
            this.InitViews();
        }

        private void InitDatabase()
        {
            var dataDocument = new XDocument(new XElement("data"));
            projectExtent = new XmlExtent(dataDocument, uri);
            this.pool.Add(projectExtent, null, "ProjektMeister");
        }

        private void InitTypes()
        {
            var typeDocument = new XDocument(new XElement("types"));
            typeExtent = new XmlExtent(typeDocument, typeUri);
            this.pool.Add(typeExtent, null, "ProjektMeister Types");

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

            var personTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.PersonTable = new DotNetObject(viewExtent, personTableView);
            viewExtent.Add(Views.PersonTable);

            var taskTableView = new DatenMeister.Entities.FieldInfos.TableView();
            Views.TaskTable = new DotNetObject(viewExtent, taskTableView);
            viewExtent.Add(Views.TaskTable);
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
        }
    }
}
