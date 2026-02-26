using System;
using System.ComponentModel;
using System.Windows.Controls;

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
            LocalizationManager.Instance.PropertyChanged += OnCultureChanged;
            Unloaded += (s, args) => LocalizationManager.Instance.PropertyChanged -= OnCultureChanged;
        }

        private void OnCultureChanged(object? sender, PropertyChangedEventArgs e)
        {
            UpdateDirectTextBoxInitialText();
        }

        private void UpdateDirectTextBoxInitialText()
        {
            if (DirectTextBox1 != null)
            {
                DirectTextBox1.Text = LocalizationManager.Instance.DirectBindingText;
            }
        }
    }
}
