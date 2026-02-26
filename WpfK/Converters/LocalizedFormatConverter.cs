using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfK.Converters
{
    /// <summary>Конвертер для форматирования строк с локализованным шаблоном из ResourceDictionary.</summary>
    public class LocalizedFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string key)
                return value?.ToString() ?? string.Empty;

            var format = LocManager.GetString(key);
            return string.Format(CultureInfo.CurrentUICulture, format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
