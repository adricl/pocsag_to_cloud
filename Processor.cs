using System;
using System.Collections.Generic;
using pocsag_to_cloud.AzureTables;

namespace pocsag_to_cloud
{
    public class Processor
    {
        private readonly Uploader messageUploader;
        private readonly Uploader AddressUploader;
        private List<string> filterList; 
        public Processor(Settings settings)
        {
            messageUploader = new Uploader(settings.PocsagTableName, settings.AzureConnectionString);
            AddressUploader = new Uploader(settings.AddressTableName, settings.AzureConnectionString);
            filterList = settings.SkipAddresses;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.In.ReadLine();
                var message = new PocsagMessage();
                if (message.ParseMessage(input))
                {
                    if (!filterList.Contains(message.Address.ToString()))
                    {
                        var address = new PocsagAddress(){
                            Address = message.Address,
                            Function = message.Function,
                            Protocol = message.Protocol,
                            PartitionKey = "Addresses",
                            RowKey = message.Address.ToString()
                        };

                        AddressUploader.Upload(address);
                        messageUploader.Upload(message);
                    }
                        
                }
            }
        }
    }
}
