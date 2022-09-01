namespace Ptichki.Mappings.Tools.Connection
{
    public static class TestingMapper
    {
        public static LayerModel ToLayer(this LibraryModel libraryModel) =>
            new()
            {
                //Type = LibraryModel.Type,
            };

        public static LibraryModel ToLibrary(this LayerModel layerModel) =>
            new()
            {
                //Type = layerModel.Type,
            };
    }

    public class LibraryModel
    {
        public const string Type = "a";
    }

    public class LayerModel
    {
        public const string Type = "s";
    }
}
