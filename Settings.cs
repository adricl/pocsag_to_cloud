using System.Collections.Generic;

namespace pocsag_to_cloud
{
    public class Settings
    {
        public string AzureConnectionString { get; set; }
        public string PocsagTableName {get;set;}
        public string AddressTableName {get;set;}
        public List<string> SkipAddresses { get; set; }
    }
}
