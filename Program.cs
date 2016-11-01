using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var uploader = new Uploader();
            while(true)
            {
                string input = Console.In.ReadLine();
                var message = new PocsagMessage();
                if (message.ParseMessage(input))
                {
                    uploader.UploadMessage(message);
                }
            }
        }
    }
}
