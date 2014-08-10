using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SisLar.Model
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            string returnValue = string.Empty;
            if ((bool)value == true)
            {
                returnValue = "Sim";
                return (string)returnValue;
            }
            else
            {
                returnValue = "Não";
                return (string)returnValue;
            }
        }

        public object ConvertBack(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
