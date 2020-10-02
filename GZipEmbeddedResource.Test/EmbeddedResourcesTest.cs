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
            Assert.AreEqual(99621885, text.Length);
            Assert.IsTrue(text.StartsWith(@"<mediawiki xmlns="));
        }
    }
}
