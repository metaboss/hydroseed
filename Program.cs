using System;
using System.IO;
using System.Net;

namespace hydroseed
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("seedsources.txt"))
            {
                var sources = File.ReadAllLines("seedsources.txt");


                foreach (string url in sources)
                {
                    WebClient client = new WebClient();

                    try
                    {
                        var seedFile = client.DownloadData(url);
                        SeedDB seedDB = new SeedDB(seedFile);
                        var dir = Directory.CreateDirectory("fbi" + Path.DirectorySeparatorChar + "seed");


                        foreach (var seed in seedDB.Seeds)
                        {
                            File.WriteAllBytes(dir.FullName + Path.DirectorySeparatorChar + seed.TitleId + ".dat", seed.SeedValue);
                        }
                        Console.WriteLine("Created dats for {0} titles.", seedDB.Count);
                    }
                    catch (WebException we)
                    {
                        Console.WriteLine(we.InnerException.Message + " " + url);
                    }
                }
            }
            else
            {
                Console.WriteLine("Required file seedsources.txt does not exist. Create a file with url sources, one per line.");
            }
        }
    }
}
