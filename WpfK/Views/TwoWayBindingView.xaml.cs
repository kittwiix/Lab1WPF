using System;
using System.Windows.Controls;
using WpfK.L10n;

namespace WpfK.Views
{
    public partial class TwoWayBindingView : UserControl
    {
        public TwoWayBindingView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации TwoWayBindingView: {ex.Message}");
                throw;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateDirectTextBoxInitialText();
            LocalizationProvider.Instance.PropertyChanged += OnCultureChanged;
            Unloaded += (s, args) => LocalizationProvider.Instance.PropertyChanged -= OnCultureChanged;
        }

        private void OnCultureChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateDirectTextBoxInitialText();
        }

        private void UpdateDirectTextBoxInitialText()
        {
            if (DirectTextBox1 != null)
            {
                DirectTextBox1.Text = LocalizationProvider.Instance.DirectBindingText;
            }
        }
    }
}
