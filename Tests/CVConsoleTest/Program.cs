using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CVConsoleTest
{
    internal class Program
    {
        private const string dataUrl =
            @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var responce = await client.GetAsync(dataUrl, HttpCompletionOption.ResponseHeadersRead);
            return await responce.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
             using var dataStream = GetDataStream().Result;
             using var dataReader = new StreamReader(dataStream);

             while (!dataReader.EndOfStream)
             {
                 var line = dataReader.ReadLine();
                 if(string.IsNullOrWhiteSpace(line)) continue;
                 yield return line;
             }

        }

        private static DateTime[] GetDateTimes() =>GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        static void Main(string[] args)
        {
            var dates = GetDateTimes();

            Console.WriteLine(string.Join("\r\n",dates));
        }
    }
}
