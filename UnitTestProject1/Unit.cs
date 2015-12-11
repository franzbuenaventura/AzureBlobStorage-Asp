using System.Configuration;
using System.Diagnostics;
using BlobStorage_ASPNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Unit
    {
        BlobStorageMain blob = new BlobStorageMain(ConfigurationManager.AppSettings["BlobKey"], "test");
    
        [TestMethod]
        public void UploadCreateOverwriteFileTest()
        {
            blob.BlobName = "test1";
            var temp = blob.UploadCreateOverwriteFile(@"../../testImage.jpg");
            Trace.WriteLine(temp);
            // Assert
            Assert.AreNotEqual(temp,"Failed Upload");
        }

    }
}
