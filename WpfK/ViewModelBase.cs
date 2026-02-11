using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfK
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>Базовый класс ViewModel с реализацией INotifyPropertyChanged.</summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>Уведомляет представление об изменении указанного свойства.</summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(propertyName))
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в OnPropertyChanged для свойства {propertyName}: {ex.Message}");
            }
        }

        /// <summary>Безопасно устанавливает значение свойства и вызывает OnPropertyChanged.</summary>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            try
            {
                if (string.IsNullOrEmpty(propertyName))
                    return false;

                if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value))
                    return false;

                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в SetValue для свойства {propertyName}: {ex.Message}");
                return false;
            }
        }
    }
}