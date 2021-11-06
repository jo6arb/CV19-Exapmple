using System;
using System.Globalization;
using System.Windows.Data;

namespace CV19.Infrastructure.Convectors
{
    internal class CompositeConvector : Convector
    {

        public IValueConverter First { get; set; }

        public IValueConverter Second { get; set; }


        public override object Convert(object v, Type t, object p, CultureInfo c)
        {
            var result1 = First?.Convert(v, t, p, c) ?? v;
            var result2 = Second?.Convert(result1, t, p, c) ?? result1;

            return result2;


        }

        public override object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            var result2 = Second?.ConvertBack(v, t, p, c) ?? v;
            var result1 = First?.ConvertBack(result2, t, p, c) ?? result2;

            return result1;
        }
    }
}