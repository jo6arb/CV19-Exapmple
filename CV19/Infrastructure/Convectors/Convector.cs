using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CV19.Infrastructure.Convectors
{
    internal  abstract  class Convector : MarkupExtension,IValueConverter
    {
        public override object ProvideValue(IServiceProvider sp) => this;

        public abstract object Convert(object value, Type t, object p, CultureInfo c);
       
        public virtual object ConvertBack(object value, Type t, object p, CultureInfo c) 
            => throw new NotSupportedException("Обратное преобразование не поддерживается!");
    }
}