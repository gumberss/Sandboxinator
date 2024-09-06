using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace S3Stream
{
    internal class BlobReceiver
    {
        private const string connectionString = "";
        private const string containerName = "blog-test-very-cooll";
        private const string blobName = "your-append-blob.txt";
        private const string localFilePath = "./path-to-save-file.txt"; // Path where the file will be saved locally

        public static async Task Main(string[] args)
        {
            // Create the BlobServiceClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Get a reference to the blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Check if the blob exists
            if (await blobClient.ExistsAsync())
            {
                // Open the blob as a stream
                BlobDownloadInfo download = await blobClient.DownloadAsync();

                // Open a file stream to write the downloaded content to a file

                    byte[] buffer = new byte[810]; // 80KB buffer size (you can adjust this)
                    int bytesRead;

                    // Open a file stream to write the downloaded content to a file
                    using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // Read from the blob stream in chunks and write to the file
                        while ((bytesRead = await download.Content.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                        }
                    }

                Console.WriteLine($"Blob downloaded successfully and saved to {localFilePath}");
            }
            else
            {
                Console.WriteLine("The specified blob does not exist.");
            }
        }
    }
}
