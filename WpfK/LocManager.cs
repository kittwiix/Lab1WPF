using System;
using System.Windows;

namespace WpfK
{
    /// <summary>Менеджер локализации на основе XAML ResourceDictionary. Загружает словари строк при смене языка.</summary>
    public static class LocManager
    {
        public static event EventHandler? CultureChanged;

        public static string CurrentCulture { get; private set; } = "ru";

        public static void SetCulture(string cultureName)
        {
            if (CurrentCulture == cultureName)
                return;

            try
            {
                var uri = new Uri($"/WpfK;component/Resources/Strings.{cultureName}.xaml", UriKind.Relative);
                var dict = (ResourceDictionary)Application.LoadComponent(uri);
                ReplaceStringsDictionary(dict);
                CurrentCulture = cultureName;
                CultureChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocManager.SetCulture('{cultureName}'): {ex.Message}");
            }
        }

        private static void ReplaceStringsDictionary(ResourceDictionary newDict)
        {
            var app = Application.Current;
            if (app?.Resources == null)
                return;

            var merged = app.Resources.MergedDictionaries;
            for (var i = merged.Count - 1; i >= 0; i--)
            {
                var d = merged[i];
                if (d.Contains("WindowTitle") || d.Source?.OriginalString?.Contains("Strings.") == true)
                {
                    merged.RemoveAt(i);
                    break;
                }
            }
            merged.Add(newDict);
        }

        /// <summary>Получает строку по ключу из текущего ResourceDictionary (для MessageBox и кода).</summary>
        public static string GetString(string key)
        {
            try
            {
                return Application.Current?.FindResource(key) as string ?? key;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocManager.GetString('{key}'): {ex.Message}");
                return key;
            }
        }
    }
}
