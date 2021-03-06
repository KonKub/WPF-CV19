using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CV19Console
{
    class Program
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                yield return line.Replace("Korea,", "Korea");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Country, string Province, int[] Count)> GetData()
        {
            var lines = GetDataLines().Skip(1).Select(line=>line.Split(','));

            foreach(var row in lines)
            {
                var province = row[0].Trim();
                var country = row[1].Trim(' ','"');
                var count = row.Skip(5).Select(int.Parse).ToArray();
                //строки var count = row.Skip(4).ToArray();

                yield return (country, province, count);
            }
        }


        static void Main(string[] args)
        {

            //var client = new WebClient();
            //var client = new HttpClient();

            //var response = client.GetAsync(data_url).Result;
            //var csv_str = response.Content.ReadAsStringAsync().Result;

            //foreach(var dl in GetDataLines())
            //    Console.WriteLine(dl);

            //var dates = GetDates();
            //Console.WriteLine(string.Join("\r\n", dates));

            var RusData = GetData().First(v=>v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join("\r\n",GetDates().Zip(RusData.Count, (date, count)=>$"{date:dd:MM:yyyy} - {count}")));


            Console.ReadLine();
        }
    }
}
