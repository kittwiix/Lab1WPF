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
    }
}
