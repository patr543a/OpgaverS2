using System;
using System.Globalization;
using System.Windows.Data;

namespace SqlRocket.Converters
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var d = (DateTime?)value ?? DateTime.MinValue;

            return d.ToString("d");
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            return DateTime.Parse((string?)value ?? DateTime.MinValue.ToString("d"));
        }
    }
}
