using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

public class Uploader
{
    CloudTable table;
    public Uploader()
    {
        var storageAccount = CloudStorageAccount.Parse("");
        var tableClient = storageAccount.CreateCloudTableClient();
        var table = tableClient.GetTableReference("people");
        table.CreateIfNotExistsAsync();
    }
    
    public void UploadMessage(PocsagMessage message){
        var insert = TableOperation.Insert(message);
        table.ExecuteAsync(insert);
    } 
}