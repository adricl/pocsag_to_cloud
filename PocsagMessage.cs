using System;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Storage.Table;

namespace pocsag_to_cloud
{
    public class PocsagMessage : TableEntity
    {
        public string Message { get; set;}
        public int Address {get;set;}
        public int Function {get;set;}
        public string Protocol {get;set;}
        public DateTime DateTime {get; private set;}

        private string RegexPattern = @"^([^:]*): Address: *(\d*)\s Function: *(\d*)\s Alpha: (.*)$";
        public PocsagMessage()
        {
            DateTime = DateTime.Now;
        }
    
        public bool ParseMessage(string message){
            var regex = new Regex(RegexPattern, RegexOptions.IgnoreCase);
            var matches =  regex.Split(message);
            var count = 0;
            Console.WriteLine("Count: " + matches.Length);
            if (matches.Length != 6)
                return false;

            foreach(var match in matches){
                switch(count){
                    case 1:
                        Console.WriteLine("Case 1: " + match);
                        Protocol = match;                    
                        break;
                    case 2:
                        Console.WriteLine("Case 2: " + match);
                        int address;
                        int.TryParse(match, out address);
                        Address = address;
                        break;
                    case 3:
                        Console.WriteLine("Case 3: " + match);
                        int function;
                        int.TryParse(match, out function);
                        Function = function; 
                        break;
                    case 4:
                        Console.WriteLine("Case 4: " + match.Trim());
                        Message = match.Trim();
                        break;
                }
                count++;
            }
            PartitionKey = Address.ToString();
            RowKey = DateTime.ToString("o");
            return true;
        }

    }
}