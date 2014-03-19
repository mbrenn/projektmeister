using DatenMeister;
using DatenMeister.DataProvider;
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
            pool = new DatenMeisterPool();
            var dataDocument = new XDocument(new XElement("data"));
            projectExtent = new XmlExtent(dataDocument, uri);
            pool.Add(projectExtent, null, "ProjektMeister");

            var typeDocument = new XDocument(new XElement("types"));
            typeExtent = new XmlExtent(typeDocument, typeUri);
            pool.Add(typeExtent, null, "ProjektMeister Types");

            // Creates the types
            Types.Person = typeExtent.CreateObject();
            var person = new DatenMeister.Entities.AsObject.Uml.Type(Types.Person);
            person.setName("Person");

            Types.Task = typeExtent.CreateObject();
            var task = new DatenMeister.Entities.AsObject.Uml.Type(Types.Task);
            task.setName("Task");
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
    }
}
