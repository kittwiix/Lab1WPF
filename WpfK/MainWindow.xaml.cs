using System;
using System.Windows;

namespace WpfK
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                
                var viewModel = new BindingViewModel();
                DataContext = viewModel;
                
                // Устанавливаем Title после установки DataContext
                if (viewModel != null && !string.IsNullOrEmpty(viewModel.Title))
                {
                    Title = viewModel.Title;
                }
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
    }
}