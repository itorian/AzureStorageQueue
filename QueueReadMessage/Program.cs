using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace ConsoleApp15
{

    // Reading message from queue

    class Program
    {
        private const string StorageAccountName = "";
        private const string StorageAccountKey = "";

        static async Task Main(string[] args)
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(StorageAccountName, StorageAccountKey), true);

            var client = storageAccount.CreateCloudQueueClient();
            var queue = client.GetQueueReference("test-queue");
            await queue.CreateIfNotExistsAsync();

            while (true)
            {
                var message = await queue.GetMessageAsync();
                if (message != null)
                {
                    Console.WriteLine("Message is " + message.AsString);
                    await queue.DeleteMessageAsync(message);
                }
            }
        }
    }
}