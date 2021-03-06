using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CV19.Models;
using CV19.Services.Interfaces;

namespace CV19.Services
{
    internal class DataService : IDataService
    {
        private const string _dataSourceAddress =
            @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var responce = await client.GetAsync(
                _dataSourceAddress,
                HttpCompletionOption.ResponseHeadersRead);
            return await responce.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var dataStream = (SynchronizationContext.Current is null ? GetDataStream() : Task.Run(GetDataStream)).Result;
            using var dataReader = new StreamReader(dataStream);

            while (!dataReader.EndOfStream)
            {
                var line = dataReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line
                    .Replace("Korea,", "Korea -")
                    .Replace("Bonaire,", "Bonaire -")
                    .Replace("Helena,", "Helena -");
            }

        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Province, string Counry, (double lat, double lon) Place, int[] Count)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country = row[1].Trim(' ', '"');
                NumberStyles style = NumberStyles.AllowDecimalPoint;
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                double latitude;
                double longitude;
                Double.TryParse(row[2], style, formatter, out latitude);
                Double.TryParse(row[3], style, formatter, out longitude);
                var counts = row.Skip(5).Select(int.Parse).ToArray();

                yield return (province, country, (latitude, longitude), counts);
            }
        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();
            var data = GetCountriesData().GroupBy(d => d.Counry);

            foreach (var countryInfo in data)
            {
                var country = new CountryInfo
                {
                    Name = countryInfo.Key,
                    ProvinceCounts = countryInfo.Select(c => new PlaceInfo
                    {
                        Name = c.Province,
                        Location = new Point(c.Place.lat, c.Place.lon),
                        Counts = dates.Zip(c.Count, (date, count) => new ConfirmedCount{ Date = date, Count = count})
                    })
                };

                yield return country;
            }

        }
    }
}