using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TryMLearning.Persistence.Helpers
{
    public static class StorageUtils
    {
        public static async Task<CloudQueue> GetQueue(string storageName, string queueName)
        {
            var storageAccountSetting = CloudConfigurationManager.GetSetting(storageName);
            var storageAccount = CloudStorageAccount.Parse(storageAccountSetting);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync();

            return queue;
        }
    }
}