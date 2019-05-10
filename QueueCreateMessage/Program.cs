using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

namespace ConsoleApp14
{

    // Writing message in queue

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

            for (int number = 0; number < 5; number++)
            {
                await queue.AddMessageAsync(new CloudQueueMessage(number.ToString()));
            }

            Console.WriteLine("Message add completed");
        }
    }
}