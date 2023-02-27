using System;
using System.Globalization;
using System.Windows.Data;

namespace SqlRocket.Converters
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class MeterConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            var d = (decimal?)value ?? 0m;

            return $"{d:0.##} m";
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            return decimal.Parse(((string?)value ?? "0 m")[..^3]);
        }
    }
}
