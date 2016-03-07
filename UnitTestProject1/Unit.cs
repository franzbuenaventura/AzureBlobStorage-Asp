using System.Configuration;
using System.Diagnostics;
using System.IO;
using BlobStorage_ASPNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Unit
    {
        BlobStorageMain blob = new BlobStorageMain(ConfigurationManager.AppSettings["BlobKey"], "test");
    
        [TestMethod]
        public void UploadCreateOverwriteFile_TestPath()
        {
            blob.BlobName = "test1";
            var temp = blob.UploadCreateOverwriteFile(@"../../testImage.jpg");
            Trace.WriteLine("Path Test: "+temp);
            // Assert
            Assert.AreNotEqual(temp,"Failed Upload");
        }
        [TestMethod]
        public void UploadCreateOverwriteFile_TestStream()
        {
            blob.BlobName = "test1";
            FileStream stream = new FileStream(@"../../testImage.jpg", FileMode.Open);
            var temp = blob.UploadCreateOverwriteFile(stream);
            Trace.WriteLine("Stream Test: "+temp);
            // Assert
            Assert.AreNotEqual(temp, "Failed Upload");
        }

    }
}
