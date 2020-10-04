using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace GZipEmbeddedResource
{
    public static class AssemblyResourceLoader
    {
        public static string GetStringFromResourceThatContains(string partialResourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string resourceName = FindResourceName(assembly, partialResourceName);

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var decompressStream = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(decompressStream))
            {
                return reader.ReadToEnd();
            }
        }

        static string FindResourceName(Assembly assembly, string partialResourceName)
        {
            var allResourceNames = assembly.GetManifestResourceNames();

            var resourceNames = allResourceNames
                .Where(s => s.Contains(partialResourceName))
                .ToArray();

            if (resourceNames.Length == 0)
            {
                throw new ArgumentException("Could not find any resource. The desired file might not have been defined as Embedded Resource.");
            }
            else if (resourceNames.Length != 1)
            {
                throw new ArgumentException($"Ambiguous name, cannot identify resource - found {resourceNames.Length} possible candidates.");
            }

            var resourceName = resourceNames[0];
            return resourceName;
        }
    }
}
