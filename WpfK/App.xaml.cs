using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfK
{
    public partial class App : Application
    {
        /// <summary>Точка входа WPF-приложения с подключением обработчиков ошибок.</summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Обработка необработанных исключений
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>Обработка необработанных исключений на UI-потоке.</summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show($"Необработанное исключение: {e.Exception.Message}\n\n{e.Exception.StackTrace}",
                    "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                // Если MessageBox тоже падает, просто логируем
                System.Diagnostics.Debug.WriteLine($"Критическая ошибка: {e.Exception}");
            }
            e.Handled = true; // Помечаем как обработанное, чтобы приложение не закрылось
        }

        /// <summary>Обработка критических исключений домена приложений.</summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is Exception ex)
                {
                    MessageBox.Show($"Необработанное исключение домена: {ex.Message}\n\n{ex.StackTrace}",
                        "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Критическая ошибка домена: {e.ExceptionObject}");
            }
        }
    }
}