/*
 UdgerParser - test speed 
 
  author     The Udger.com Team (info@udger.com)
  license    GNU Lesser General Public License
  link       http://udger.com/products/local_parser
*/

using Udger.Parser;
using System.Net;
using System.IO;
using System;

namespace test_ua_ip
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string line;
            long start_time, elapsed_time;
            Udger.Parser.UserAgent a;
            Udger.Parser.IPAddress i;


            Console.WriteLine("start");
            // Create a new UdgerParser object
            UdgerParser parser = new UdgerParser();

            // Set data dir (in this directory is stored data file: udgerdb_v3.dat)
            // Data file can be downloaded manually from http://data.udger.com/, but we recommend use udger-updater
            parser.SetDataDir(@"C:\udger");

            Console.WriteLine("download test UA file start");
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/udger/test-data/master/test_ua-ip/ua_1000.txt");
            StreamReader reader = new StreamReader(stream);            
            Console.WriteLine("download test UA file end");


            Console.WriteLine("parse UA start");
            start_time = DateTime.Now.Ticks;

            while ((line = reader.ReadLine()) != null)
            {                
                line = line.Trim();
                parser.ua = line;
                // Parse
                parser.parse();
                a = parser.userAgent;
            }


            elapsed_time = (DateTime.Now.Ticks - start_time) /10;
            Console.WriteLine("parse UA end, time: " + elapsed_time);

            // Suspend the screen.
            Console.ReadLine();

        }
    }
}
