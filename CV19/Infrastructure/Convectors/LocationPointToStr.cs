using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CV19.Infrastructure.Convectors
{
    [ValueConversion(typeof(Point), typeof(string))]

    internal class LocationPointToStr : Convector
    {
        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is Point point)) return null;
            
            return $"Lat: {point.X}; Lon: {point.Y}";
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is string str)) return null;
            var component = str.Split(";");
            var latStr = component[0].Split(":")[1];
            var lonStr = component[1].Split(":")[1];

            var lat = double.Parse(latStr, CultureInfo.InvariantCulture);
            var lon = double.Parse(lonStr, CultureInfo.InvariantCulture);

            return new Point(lat, lon);
        }
    }
}