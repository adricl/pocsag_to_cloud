using System;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Storage.Table;

namespace pocsag_to_cloud.AzureTables
{
    public class PocsagAddress : TableEntity
    {
        public int Address {get;set;}
        public int Function {get;set;}
        public string Protocol {get;set;}
        public string Description {get; set;}
        public PocsagAddress() {

        }

    }
}