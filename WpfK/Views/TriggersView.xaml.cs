using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfK.Views
{
    public partial class TriggersView : UserControl
    {
        /// <summary>Инициализирует вкладку с примерами разных типов триггеров.</summary>
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

        /// <summary>Заполняет таблицу краткими описаниями триггеров.</summary>
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
        /// <summary>Человекочитаемое название триггера.</summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>Краткое условие, при котором срабатывает триггер.</summary>
        public string Condition { get; set; } = string.Empty;
        /// <summary>Пример использования конкретного триггера.</summary>
        public string Example { get; set; } = string.Empty;
    }
}
