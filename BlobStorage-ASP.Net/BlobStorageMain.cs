using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace BlobStorage_ASPNet
{
    public class BlobStorageMain
    {
        public string BlobName { get; set; }
        public CloudBlobContainer CloudContainer { get; set; }

        public BlobStorageMain(string connectionString, string container)
        {

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudContainer = blobClient.GetContainerReference(container);
            CloudContainer.CreateIfNotExists();
        }

        public string UploadCreateOverwriteFile(Stream stream)
        {
            try
            {
                // Retrieve reference to a blob and use BlobName as a name
                CloudBlockBlob blockBlob = CloudContainer.GetBlockBlobReference(BlobName);
                blockBlob.UploadFromStream(stream);
                return blockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return "Failed Upload";
            }
        }

        public string UploadCreateOverwriteFile(string path)
        {
            try
            {
                CloudBlockBlob blockBlob = CloudContainer.GetBlockBlobReference(BlobName);
                //path - The path of the file that will be uploaded
                using (var fileStream = System.IO.File.OpenRead(path))
                {
                    blockBlob.UploadFromStream(fileStream);
                }
                return blockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return "Failed Upload";                    
            }
        }




    }
}
