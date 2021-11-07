using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CV19.Infrastructure.Convectors
{
    [MarkupExtensionReturnType(typeof(CompositeConvector))]
    internal class CompositeConvector : Convector
    {
        [ConstructorArgument("First")]
        public IValueConverter First { get; set; }

        [ConstructorArgument("Second")]
        public IValueConverter Second { get; set; }

        public CompositeConvector() { }
        public CompositeConvector(IValueConverter first) => this.First = first;
        public CompositeConvector(IValueConverter first, IValueConverter second) : this(first) => this.Second = second;


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