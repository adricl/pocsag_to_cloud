using System.Collections.Generic;

namespace pocsag_to_cloud
{
    public class Settings
    {
        public string AzureConnectionString { get; set; }
        public List<string> SkipAddresses { get; set; }
    }
}
