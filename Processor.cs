using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
