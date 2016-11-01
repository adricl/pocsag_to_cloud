using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace pocsag_to_cloud
{
    public class Uploader
    {
        readonly CloudTable table;
        public Uploader()
        {
            var storageAccount = CloudStorageAccount.Parse("");
            var tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("pocsag");
            table.CreateIfNotExistsAsync();
        }
    
        public void UploadMessage(PocsagMessage message){
            var insert = TableOperation.Insert(message);
            table.ExecuteAsync(insert);
        } 
    }
}