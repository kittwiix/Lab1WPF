using System;
using System.Windows.Controls;

namespace WpfK.Views
{
    public partial class OneWayBindingView : UserControl
    {
        public OneWayBindingView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации OneWayBindingView: {ex.Message}");
                throw;
            }
        }
    }
}
