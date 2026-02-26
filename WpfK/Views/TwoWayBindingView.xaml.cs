using System;
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
            LocManager.CultureChanged += OnCultureChanged;
            Unloaded += (s, args) => LocManager.CultureChanged -= OnCultureChanged;
        }

        private void OnCultureChanged(object? sender, EventArgs e)
        {
            UpdateDirectTextBoxInitialText();
        }

        private void UpdateDirectTextBoxInitialText()
        {
            if (DirectTextBox1 != null)
            {
                DirectTextBox1.Text = LocManager.GetString("DirectBindingText");
            }
        }
    }
}
