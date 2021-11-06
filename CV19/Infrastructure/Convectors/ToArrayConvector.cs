using System;
using System.Globalization;
using System.Windows.Data;

namespace CV19.Infrastructure.Convectors
{
    internal class ToArrayConvector : MultiConvector
    {
        public override object Convert(object[] vv, Type t, object p, CultureInfo c)
        {
            var collection = new CompositeCollection();
            foreach (var value in vv)
                collection.Add(value);
            return collection;

        }
    }
}