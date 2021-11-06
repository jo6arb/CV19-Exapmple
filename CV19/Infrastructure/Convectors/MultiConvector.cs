﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace CV19.Infrastructure.Convectors
{
    internal abstract class MultiConvector : IMultiValueConverter
    {
        public abstract object Convert(object[] vv, Type t, object p, CultureInfo c);

        public virtual object[] ConvertBack(object v, Type[] tt, object p, CultureInfo c) =>
            throw new NotSupportedException("Обратное преобразование не поддерживается!");
    }
}