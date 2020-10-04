using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GZipEmbeddedResource.Test
{
    [TestClass]
    public class EmbeddedResourcesTest
    {
        [TestMethod]
        public void EmbeddedResourcesTest_enwik8()
        {   
            var text = EmbeddedResources.enwik8;

            Assert.IsNotNull(text);
            // Length depends on line endings,
            // be aware that embedding will use line endings 
            // as per build time git repository state.
            Assert.IsTrue(text.Length >= 99621885); 
            Assert.IsTrue(text.StartsWith(@"<mediawiki xmlns="));
        }
    }
}
