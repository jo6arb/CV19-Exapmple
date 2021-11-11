using System;
using System.Globalization;

namespace CV19.Infrastructure.Convectors
{
    internal class DebugConvector : Convector
    {
        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            System.Diagnostics.Debugger.Break();
            return value;
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
           System.Diagnostics.Debugger.Break();
            return value;
        }
    }
}
