using System.IO;
using Newtonsoft.Json;

namespace pocsag_to_cloud
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Settings settings;
            if (args.Length > 0)
                settings = LoadJsonSettings(args[0]);
            else 
                return -1;

            var processor = new Processor(settings);
            processor.Run();

            return 0;
        }
        private static Settings LoadJsonSettings(string fileName)
        {
            using (var file = File.OpenText(fileName))
            {
                var json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<Settings>(json);
            }
        }
    }
}
