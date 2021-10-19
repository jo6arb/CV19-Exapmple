using System;
using System.Net.Http;

namespace CVConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string dataUrl =
                @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

            var client = new HttpClient();

            var response = client.GetAsync(dataUrl).Result;
            var csvStr =response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(csvStr);
        }
    }
}
