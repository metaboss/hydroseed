using System;
using System.IO;
using System.Net;

namespace hydroseed
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedDB seedDB = new SeedDB();
            if (args.Length > 0 && File.Exists(args[0]))
            {
                seedDB = new SeedDB(File.ReadAllBytes(args[0]));
            }
            else if (File.Exists("seedsources.txt"))
            {
                var sources = File.ReadAllLines("seedsources.txt");


                foreach (string url in sources)
                {
                    WebClient client = new WebClient();

                    try
                    {
                        seedDB = new SeedDB(client.DownloadData(url));
                    }
                    catch (WebException we)
                    {
                        Console.WriteLine(we.InnerException.Message + " " + url);
                    }
                }
            }
            else
            {
                Console.WriteLine("No input file or seedsources.txt file found.");
            }
            if (seedDB.Count > 0)
            {
                var dir = Directory.CreateDirectory("fbi" + Path.DirectorySeparatorChar + "seed");

                foreach (var seed in seedDB.Seeds)
                {
                    File.WriteAllBytes(dir.FullName + Path.DirectorySeparatorChar + seed.TitleId + ".dat", seed.SeedValue);
                }
                Console.WriteLine("Created dats for {0} titles.", seedDB.Count);
            }
        }
    }
}