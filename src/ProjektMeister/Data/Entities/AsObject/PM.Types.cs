namespace ProjektMeister.Data.Entities.AsObject
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpTypeDefinitionFactory", "1.0.8.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public static partial class Types
    {
        public const string DefaultExtentUri="datenmeister:///projektmeister/types";

        public static DatenMeister.IURIExtent Init()
        {
            var extent = new DatenMeister.DataProvider.DotNet.DotNetExtent(DefaultExtentUri);
            DatenMeister.Entities.AsObject.Uml.Types.AssignTypeMapping(extent);
            Init(extent);
            return extent;
        }

        public static void Init(DatenMeister.IURIExtent extent)
        {
            var factory = DatenMeister.DataProvider.Factory.GetFor(extent);
            if(Types.Comment == null || true)
            {
                Types.Comment = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Class);
                DatenMeister.Entities.AsObject.Uml.Type.setName(Types.Comment, "Comment");
                extent.Elements().add(Types.Comment);
            }

            if(Types.Person == null || true)
            {
                Types.Person = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Class);
                DatenMeister.Entities.AsObject.Uml.Type.setName(Types.Person, "Person");
                extent.Elements().add(Types.Person);
            }

            if(Types.Task == null || true)
            {
                Types.Task = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Class);
                DatenMeister.Entities.AsObject.Uml.Type.setName(Types.Task, "Task");
                extent.Elements().add(Types.Task);
            }


            if(extent is DatenMeister.DataProvider.DotNet.DotNetExtent)
            {
                (extent as DatenMeister.DataProvider.DotNet.DotNetExtent).AddDefaultMappings();
            }

            OnInitCompleted();

            {
                // Comment.created
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "created");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Comment, property);
            }

            {
                // Comment.author
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "author");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Comment, property);
            }

            {
                // Comment.body
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "body");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Comment, property);
            }

            {
                // Person.firstname
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "firstname");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Person, property);
            }

            {
                // Person.name
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "name");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Person, property);
            }

            {
                // Person.email
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "email");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Person, property);
            }

            {
                // Person.phone
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "phone");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Person, property);
            }

            {
                // Person.title
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "title");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Person, property);
            }

            {
                // Task.name
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "name");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Task, property);
            }

            {
                // Task.startdate
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "startdate");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Task, property);
            }

            {
                // Task.enddate
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "enddate");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Task, property);
            }

            {
                // Task.responsible
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "responsible");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Task, property);
            }

            {
                // Task.finished
                var property = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Property);
                DatenMeister.Entities.AsObject.Uml.Property.setName(property, "finished");
                DatenMeister.Entities.AsObject.Uml.Class.pushOwnedAttribute(Types.Task, property);
            }

        }

        public static DatenMeister.IObject Comment;

        public static DatenMeister.IObject Person;

        public static DatenMeister.IObject Task;


        public static void AssignTypeMapping(DatenMeister.DataProvider.DotNet.DotNetExtent extent)
        {
            AssignTypeMapping(extent.Mapping);
        }

        public static void AssignTypeMapping(DatenMeister.DataProvider.DotNet.IMapsMetaClassFromDotNet mapping)
        {
            mapping.Add(typeof(ProjektMeister.Data.Entities.Comment), Types.Comment);
            mapping.Add(typeof(ProjektMeister.Data.Entities.Person), Types.Person);
            mapping.Add(typeof(ProjektMeister.Data.Entities.Task), Types.Task);
        }

        static partial void OnInitCompleted();
    }
}
