namespace ProjektMeister.Data.Entities.AsObject
{
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
            if(Types.Person == null || true)
            {
                Types.Person = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Type);
                DatenMeister.Entities.AsObject.Uml.Type.setName(Types.Person, "Person");
                extent.Elements().add(Types.Person);
            }

            if(Types.Task == null || true)
            {
                Types.Task = factory.create(DatenMeister.Entities.AsObject.Uml.Types.Type);
                DatenMeister.Entities.AsObject.Uml.Type.setName(Types.Task, "Task");
                extent.Elements().add(Types.Task);
            }

            if(extent is DatenMeister.DataProvider.DotNet.DotNetExtent)
            {
                (extent as DatenMeister.DataProvider.DotNet.DotNetExtent).AddDefaultMappings();
            }

            OnInitCompleted();
        }

        public static DatenMeister.IObject Person;

        public static DatenMeister.IObject Task;


        public static void AssignTypeMapping(DatenMeister.DataProvider.DotNet.DotNetExtent extent)
        {
            extent.Mapping.Add(typeof(ProjektMeister.Data.Entities.Person), Types.Person);
            extent.Mapping.Add(typeof(ProjektMeister.Data.Entities.Task), Types.Task);
        }

        static partial void OnInitCompleted();
    }
}
