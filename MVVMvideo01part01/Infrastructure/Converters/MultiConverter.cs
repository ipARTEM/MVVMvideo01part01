using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MVVMvideo04part04.Infrastructure.Converters
{
    internal abstract class MultiConverter : IMultiValueConverter
    {
        public abstract object Convert(object[] vv, Type t, object p, CultureInfo c);  


        public object[] ConvertBack(object v, Type[] tt, object p, CultureInfo c)
        {
            throw new NotSupportedException("Обратное преобразование не поддерживается");
        }
    }
}
