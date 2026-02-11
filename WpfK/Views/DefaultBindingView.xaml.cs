using System;
using System.Windows.Controls;

namespace WpfK.Views
{
    public partial class DefaultBindingView : UserControl
    {
        public DefaultBindingView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации DefaultBindingView: {ex.Message}");
                throw;
            }
        }
    }
}
