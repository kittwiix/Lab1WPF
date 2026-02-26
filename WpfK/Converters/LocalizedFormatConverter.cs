using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfK.Converters
{
    /// <summary>Конвертер для форматирования строк с локализованным шаблоном.</summary>
    public class LocalizedFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string key)
                return value?.ToString() ?? string.Empty;

            var format = LocalizationManager.Instance.GetString(key);
            return string.Format(LocalizationManager.Instance.CurrentCulture, format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
