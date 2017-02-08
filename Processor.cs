using System;
using System.Collections.Generic;

namespace pocsag_to_cloud
{
    public class Processor
    {
        private readonly Uploader uploader;
        private List<string> filterList; 
        public Processor(Settings settings)
        {
            uploader = new Uploader(settings.AzureConnectionString);
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
                        uploader.UploadMessage(message);
                }
            }
        }
    }
}
