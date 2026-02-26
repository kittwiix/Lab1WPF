using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfK
{
    public partial class MainWindow : Window
    {
        /// <summary>Главное окно приложения, инициализирующее привязки.</summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                
                var viewModel = new BindingViewModel();
                DataContext = viewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации приложения: {ex.Message}\n\n{ex.StackTrace}", 
                    "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                try
                {
                    Application.Current?.Shutdown();
                }
                catch
                {
                    Environment.Exit(1);
                }
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox?.SelectedItem is ComboBoxItem item && item.Tag is string cultureName)
            {
                LocalizationManager.Instance.SetCulture(cultureName);
            }
        }
    }
}