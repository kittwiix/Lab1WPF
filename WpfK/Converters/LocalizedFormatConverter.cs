using System;
using System.Globalization;
using System.Windows.Data;
using WpfK.L10n;

namespace WpfK.Converters
{
    /// <summary>Конвертер для форматирования строк с локализованным шаблоном из внешней библиотеки.</summary>
    public class LocalizedFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string key)
                return value?.ToString() ?? string.Empty;

            var format = LocalizationProvider.Instance.GetString(key);
            return string.Format(CultureInfo.CurrentUICulture, format, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
