using System;
using System.Globalization;

namespace CV19.Infrastructure.Convectors
{

    /// <summary> Реализация линейного преобразования f(x) = k*x + b</summary>
    internal class Linear : Convector
    {
        public double K { get; set; } = 1;
        public double B { get; set; } 

        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is null)) return null;

            var x = System.Convert.ToDouble(value, c);

            return K * x + B;
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
             if (!(value is null)) return null;

            var y = System.Convert.ToDouble(value, c);

            return (y - B) / K;
        }
    }
}