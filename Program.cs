using System;

namespace pocsag_to_cloud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var uploader = new Uploader();
            while(true)
            {
                var input = Console.In.ReadLine();
                var message = new PocsagMessage();
                if (message.ParseMessage(input))
                {
                    uploader.UploadMessage(message);
                }
            }
        }
    }
}
