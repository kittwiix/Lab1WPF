using System;
using System.Windows;
using System.Windows.Input;

namespace WpfK
{
    public class SimpleCommand : ICommand
    {
        /// <summary>Делегат действия, выполняемого командой.</summary>
        private readonly Action _execute;
        /// <summary>Необязательная функция проверки доступности команды.</summary>
        private readonly Func<bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public SimpleCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>Определяет, можно ли выполнить команду в текущем состоянии.</summary>
        public bool CanExecute(object? parameter)
        {
            try
            {
                return _canExecute?.Invoke() ?? true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в CanExecute: {ex.Message}");
                return false;
            }
        }

        /// <summary>Вызывает делегат выполнения команды.</summary>
        public void Execute(object? parameter)
        {
            try
            {
                _execute();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в Execute: {ex.Message}");
                MessageBox.Show($"Ошибка выполнения команды: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}