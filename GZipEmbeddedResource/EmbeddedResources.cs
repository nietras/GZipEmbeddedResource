namespace GZipEmbeddedResource
{
    public static class EmbeddedResources
    {
        public static string enwik8 => AssemblyResourceLoader
            .GetStringFromResourceThatContains(nameof(enwik8));
    }
}
