using System;
using System.Globalization;
using System.Windows.Data;

namespace CV19.Infrastructure.Convectors
{
    internal  abstract  class Convector : IValueConverter
    {
        public abstract object Convert(object value, Type t, object p, CultureInfo c);
       
        public virtual object ConvertBack(object value, Type t, object p, CultureInfo c) 
            => throw new NotSupportedException("Обратное преобразование не поддерживается!");
    }
}