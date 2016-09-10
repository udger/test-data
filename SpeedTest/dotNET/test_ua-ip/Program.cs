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
            string                  line;
            long                    start_time, elapsed_time;
            Udger.Parser.UserAgent  a;
            Udger.Parser.IPAddress  i;
            WebClient               client;
            Stream                  stream;
            StreamReader            reader;


            Console.WriteLine("start");

            #region UdgerParse
            // Create a new UdgerParser object
            UdgerParser parser = new UdgerParser();

            // Set data dir (in this directory is stored data file: udgerdb_v3.dat)
            // Data file can be downloaded from http://data.udger.com/
            parser.SetDataDir(@"C:\udger");
            //parser.SetDataDir(@"C:\udger", "udgerdb_v3-noip.dat ");
            #endregion

            #region IP test
            Console.WriteLine("download test IP file start");
            client = new WebClient();
            stream = client.OpenRead("https://raw.githubusercontent.com/udger/test-data/master/test_ua-ip/ip_1000.txt");
            reader = new StreamReader(stream);
            Console.WriteLine("download test IP file end");


            Console.WriteLine("parse IP start");
            start_time = DateTime.Now.Ticks;

            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                parser.ip = line;
                // Parse
                parser.parse();
                i = parser.ipAddress;
            }


            elapsed_time = (DateTime.Now.Ticks - start_time) / 10;
            Console.WriteLine("parse IP end, time: " + elapsed_time);                       
            #endregion

            #region UA test
            Console.WriteLine("download test UA file start");
            client = new WebClient();
            stream = client.OpenRead("https://raw.githubusercontent.com/udger/test-data/master/test_ua-ip/ua_1000.txt");
            reader = new StreamReader(stream);            
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
            #endregion

            Console.WriteLine("end");
            // Suspend the screen.
            Console.ReadLine();
            
        }
    }
}
