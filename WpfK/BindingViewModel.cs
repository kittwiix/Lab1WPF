using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfK
{
    public class BindingViewModel : ViewModelBase
    {
        /// <summary>Заголовок окна, отображаемый в UI.</summary>
        private string _title = "Лабораторная №1";
        public string Title
        {
            get => _title ?? string.Empty;
            set => SetValue(ref _title, value ?? string.Empty);
        }

        /// <summary>Текст, который синхронизируется между контролами.</summary>
        private string _syncText = "Текст для синхронизации";
        public string SyncText
        {
            get => _syncText ?? string.Empty;
            set => SetValue(ref _syncText, value ?? string.Empty);
        }

        /// <summary>Значение прогресс-бара в диапазоне 0–100.</summary>
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

        /// <summary>Флаг для демонстрации булевой привязки.</summary>
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetValue(ref _isEnabled, value);
        }

        /// <summary>Статический текст с временем запуска приложения.</summary>
        private readonly string _initialTime = $"Запущено: {DateTime.Now:HH:mm:ss}";
        public string InitialTime => _initialTime;

        /// <summary>Текст, доступный только для чтения.</summary>
        private string _readOnlyText = "Текст только для чтения";
        public string ReadOnlyText
        {
            get => _readOnlyText ?? string.Empty;
            set => SetValue(ref _readOnlyText, value ?? string.Empty);
        }

        // Для TwoWay Binding вкладки
        /// <summary>Текст для демонстрации двухсторонней привязки.</summary>
        private string _twoWayText1 = "Двухсторонний текст";
        public string TwoWayText1
        {
            get => _twoWayText1 ?? string.Empty;
            set => SetValue(ref _twoWayText1, value ?? string.Empty);
        }

        /// <summary>Булевское значение для TwoWay привязки CheckBox.</summary>
        private bool _twoWayBool = true;
        public bool TwoWayBool
        {
            get => _twoWayBool;
            set => SetValue(ref _twoWayBool, value);
        }

        /// <summary>Числовое значение для TwoWay привязки Slider/TextBox.</summary>
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
        /// <summary>Текущее время, обновляемое таймером.</summary>
        private DateTime _currentTime = DateTime.Now;
        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetValue(ref _currentTime, value);
        }

        /// <summary>Текст, который передаётся только в источник (OneWayToSource).</summary>
        private string _oneWayToSourceText = "";
        public string OneWayToSourceText
        {
            get => _oneWayToSourceText ?? string.Empty;
            set => SetValue(ref _oneWayToSourceText, value ?? string.Empty);
        }

        // Для Triggers вкладки
        /// <summary>Текст для демонстрации работы триггеров данных.</summary>
        private string _dataTriggerText = "";
        public string DataTriggerText
        {
            get => _dataTriggerText ?? string.Empty;
            set => SetValue(ref _dataTriggerText, value ?? string.Empty);
        }

        /// <summary>Коллекция строк для примера привязки списка.</summary>
        public ObservableCollection<string> DataList { get; } = new();

        // Команды для первой вкладки
        /// <summary>Команда обновления заголовка окна.</summary>
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

        /// <summary>Команда переключения булевого флага IsEnabled.</summary>
        private ICommand? _switchCommand;
        public ICommand SwitchCommand =>
            _switchCommand ??= new SimpleCommand(() =>
            {
                IsEnabled = !IsEnabled;
            });

        /// <summary>Команда сброса значений на вкладке по умолчанию.</summary>
        private ICommand? _resetCommand;
        public ICommand ResetCommand =>
            _resetCommand ??= new SimpleCommand(() =>
            {
                SyncText = "";
                ReadOnlyText = "";
                ProgressValue = 50;
            });

        /// <summary>Команда добавления нового элемента в список.</summary>
        private ICommand? _addDataCommand;
        public ICommand AddDataCommand =>
            _addDataCommand ??= new SimpleCommand(() =>
            {
                try
                {
                    // Проверка на максимальное количество элементов
                    if (DataList.Count >= 100)
                    {
                        MessageBox.Show(LocalizationManager.Instance.MsgMaxRecords, 
                            LocalizationManager.Instance.MsgWarning, MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    DataList.Add($"Запись {DataList.Count + 1}");
                    MessageBox.Show(LocalizationManager.Instance.MsgRecordAdded,
                        LocalizationManager.Instance.MsgSuccess, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка добавления записи: {ex.Message}");
                    MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", 
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        // Команды для TwoWay вкладки
        /// <summary>Команда переключения булевого значения для TwoWay примера.</summary>
        private ICommand? _toggleTwoWayCommand;
        public ICommand ToggleTwoWayCommand =>
            _toggleTwoWayCommand ??= new SimpleCommand(() =>
            {
                TwoWayBool = !TwoWayBool;
            });

        // Команды для OneWay вкладки
        /// <summary>Команда отображения текста, записанного в ViewModel через OneWayToSource.</summary>
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