using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace CommunyStoreFrontEnd.Converters
{
    public class InverseBoolConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}