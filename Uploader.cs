using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace pocsag_to_cloud
{
    public class Uploader
    {
        readonly CloudTable table;
        public Uploader(string tableName, string azureConnectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExistsAsync();
        }
    
        public void Upload(ITableEntity message){
            var insert = TableOperation.InsertOrMerge(message);
            table.ExecuteAsync(insert);
        } 
    }
}