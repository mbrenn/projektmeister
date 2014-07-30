namespace ProjektMeister.Data.Entities.AsObject
{
    public static class Types
    {
        public static DatenMeister.IURIExtent Init()
        {
            var extent = new DatenMeister.DataProvider.DotNet.DotNetExtent("datenmeister:///projektmeister/types");
            if(Types.Person == null)
            {
                var type = new DatenMeister.Entities.UML.Type();
                type.name = "Person";
                Types.Person = new DatenMeister.DataProvider.DotNet.DotNetObject(extent, type);
                extent.Elements().add(Types.Person);
            }

            if(Types.Task == null)
            {
                var type = new DatenMeister.Entities.UML.Type();
                type.name = "Task";
                Types.Task = new DatenMeister.DataProvider.DotNet.DotNetObject(extent, type);
                extent.Elements().add(Types.Task);
            }

            extent.AddDefaultMappings();
            return extent;
        }

        public static DatenMeister.IObject Person;

        public static DatenMeister.IObject Task;


        public static void AssignTypeMapping(DatenMeister.DataProvider.DotNet.DotNetExtent extent)
        {
            extent.Mapping.Add(typeof(ProjektMeister.Data.Entities.Person), Types.Person);
            extent.Mapping.Add(typeof(ProjektMeister.Data.Entities.Task), Types.Task);
        }

    }
}
