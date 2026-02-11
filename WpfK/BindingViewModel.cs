using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfK
{
    public class BindingViewModel : ViewModelBase
    {
        private string _title = "Лабораторная №1";
        public string Title
        {
            get => _title ?? string.Empty;
            set => SetValue(ref _title, value ?? string.Empty);
        }

        private string _syncText = "Текст для синхронизации";
        public string SyncText
        {
            get => _syncText ?? string.Empty;
            set => SetValue(ref _syncText, value ?? string.Empty);
        }

        private int _progressValue = 60;
        public int ProgressValue
        {
            get => _progressValue;
            set
            {
                // Проверка границ значения
                var clampedValue = Math.Max(0, Math.Min(100, value));
                SetValue(ref _progressValue, clampedValue);
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetValue(ref _isEnabled, value);
        }

        private readonly string _initialTime = $"Запущено: {DateTime.Now:HH:mm:ss}";
        public string InitialTime => _initialTime;

        private string _readOnlyText = "Текст только для чтения";
        public string ReadOnlyText
        {
            get => _readOnlyText ?? string.Empty;
            set => SetValue(ref _readOnlyText, value ?? string.Empty);
        }

        // Для TwoWay Binding вкладки
        private string _twoWayText1 = "Двухсторонний текст";
        public string TwoWayText1
        {
            get => _twoWayText1 ?? string.Empty;
            set => SetValue(ref _twoWayText1, value ?? string.Empty);
        }

        private bool _twoWayBool = true;
        public bool TwoWayBool
        {
            get => _twoWayBool;
            set => SetValue(ref _twoWayBool, value);
        }

        private double _twoWayNumber = 50;
        public double TwoWayNumber
        {
            get => _twoWayNumber;
            set
            {
                // Проверка границ значения
                var clampedValue = Math.Max(0, Math.Min(100, value));
                SetValue(ref _twoWayNumber, clampedValue);
            }
        }

        // Для OneWay Binding вкладки
        private DateTime _currentTime = DateTime.Now;
        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetValue(ref _currentTime, value);
        }

        private string _oneWayToSourceText = "";
        public string OneWayToSourceText
        {
            get => _oneWayToSourceText ?? string.Empty;
            set => SetValue(ref _oneWayToSourceText, value ?? string.Empty);
        }

        // Для Triggers вкладки
        private string _dataTriggerText = "";
        public string DataTriggerText
        {
            get => _dataTriggerText ?? string.Empty;
            set => SetValue(ref _dataTriggerText, value ?? string.Empty);
        }

        public ObservableCollection<string> DataList { get; } = new();

        // Команды для первой вкладки
        private ICommand? _refreshCommand;
        public ICommand RefreshCommand =>
            _refreshCommand ??= new SimpleCommand(() =>
            {
                try
                {
                    Title = $"Обновлено в {DateTime.Now:HH:mm:ss}";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка обновления: {ex.Message}");
                    MessageBox.Show($"Ошибка при обновлении: {ex.Message}", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

        private ICommand? _switchCommand;
        public ICommand SwitchCommand =>
            _switchCommand ??= new SimpleCommand(() =>
            {
                IsEnabled = !IsEnabled;
            });

        private ICommand? _resetCommand;
        public ICommand ResetCommand =>
            _resetCommand ??= new SimpleCommand(() =>
            {
                SyncText = "";
                ReadOnlyText = "";
                ProgressValue = 50;
            });

        private ICommand? _addDataCommand;
        public ICommand AddDataCommand =>
            _addDataCommand ??= new SimpleCommand(() =>
            {
                try
                {
                    // Проверка на максимальное количество элементов
                    if (DataList.Count >= 100)
                    {
                        MessageBox.Show("Достигнуто максимальное количество записей (100)", 
                            "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    DataList.Add($"Запись {DataList.Count + 1}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка добавления записи: {ex.Message}");
                    MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        // Команды для TwoWay вкладки
        private ICommand? _toggleTwoWayCommand;
        public ICommand ToggleTwoWayCommand =>
            _toggleTwoWayCommand ??= new SimpleCommand(() =>
            {
                TwoWayBool = !TwoWayBool;
            });

        // Команды для OneWay вкладки
        private ICommand? _showOneWayToSourceCommand;
        public ICommand ShowOneWayToSourceCommand =>
            _showOneWayToSourceCommand ??= new SimpleCommand(() =>
            {
                try
                {
                    var displayText = string.IsNullOrEmpty(OneWayToSourceText) 
                        ? "(пусто)" 
                        : OneWayToSourceText;
                    MessageBox.Show($"Значение в ViewModel: {displayText}",
                        "OneWayToSource", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка отображения значения: {ex.Message}");
                    MessageBox.Show($"Ошибка: {ex.Message}", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        public BindingViewModel()
        {
            try
            {
                DataList.Add("Пример 1");
                DataList.Add("Пример 2");
                DataList.Add("Пример 3");

                // Запускаем таймер для обновления времени (OneWay пример)
                var timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                timer.Tick += (s, e) =>
                {
                    try
                    {
                        CurrentTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        // Логирование ошибки обновления времени
                        System.Diagnostics.Debug.WriteLine($"Ошибка обновления времени: {ex.Message}");
                    }
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка инициализации ViewModel: {ex.Message}");
                // Устанавливаем значения по умолчанию при ошибке
                if (DataList.Count == 0)
                {
                    DataList.Add("Ошибка загрузки данных");
                }
            }
        }
    }
}