using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfK.Views
{
    public partial class OneTimeBindingView : UserControl
    {
        public OneTimeBindingView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации OneTimeBindingView: {ex.Message}");
                throw;
            }
        }

        private void ChangeSourceText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SourceTextBox != null)
                {
                    SourceTextBox.Text = $"Изменено: {DateTime.Now:HH:mm:ss}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении текста: {ex.Message}", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshBinding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SourceTextBox != null && OneTimeTextBlock != null)
                {
                    // Очищаем старую привязку
                    BindingOperations.ClearBinding(OneTimeTextBlock, System.Windows.Controls.TextBlock.TextProperty);

                    // Устанавливаем новую привязку
                    var binding = new Binding("Text")
                    {
                        Source = SourceTextBox,
                        Mode = BindingMode.OneTime
                    };
                    BindingOperations.SetBinding(OneTimeTextBlock, System.Windows.Controls.TextBlock.TextProperty, binding);

                    MessageBox.Show("OneTime привязка обновлена!", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении привязки: {ex.Message}", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
