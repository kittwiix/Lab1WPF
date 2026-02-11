using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfK.Views
{
    public partial class TriggersView : UserControl
    {
        public TriggersView()
        {
            try
            {
                InitializeComponent();
                InitializeTriggersComparison();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации TriggersView: {ex.Message}");
                throw;
            }
        }

        private void InitializeTriggersComparison()
        {
            try
            {
                var triggers = new ObservableCollection<TriggerInfo>();
                triggers.Add(new TriggerInfo
                {
                    Type = "Property Trigger",
                    Condition = "Изменение свойства элемента",
                    Example = "IsMouseOver, IsEnabled"
                });
                triggers.Add(new TriggerInfo
                {
                    Type = "Data Trigger",
                    Condition = "Условие на основе данных",
                    Example = "Text.Length == 0"
                });
                triggers.Add(new TriggerInfo
                {
                    Type = "Event Trigger",
                    Condition = "Возникновение события",
                    Example = "Button.Click, MouseEnter"
                });
                triggers.Add(new TriggerInfo
                {
                    Type = "Multi Trigger",
                    Condition = "Комбинация условий свойств",
                    Example = "IsMouseOver AND IsEnabled"
                });
                triggers.Add(new TriggerInfo
                {
                    Type = "MultiData Trigger",
                    Condition = "Комбинация условий на основе данных",
                    Example = "Text.Length == 10 AND CheckBox.IsChecked"
                });

                if (TriggersComparison != null)
                {
                    TriggersComparison.ItemsSource = triggers;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации таблицы триггеров: {ex.Message}");
                // Продолжаем работу даже если таблица не загрузилась
            }
        }
    }

    public class TriggerInfo
    {
        public string Type { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public string Example { get; set; } = string.Empty;
    }
}
