using System;
using System.Collections.ObjectModel;
using WpfFuncP.ViewModels;

namespace WpfFuncP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _userName = "Панов Артем";
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }

        private string _displayText = "Демонстрация привязок";
        public string DisplayText
        {
            get => _displayText;
            set => Set(ref _displayText, value);
        }

        private double _numericValue = 75.5;
        public double NumericValue
        {
            get => _numericValue;
            set => Set(ref _numericValue, value);
        }

        private bool _toggleState = true;
        public bool ToggleState
        {
            get => _toggleState;
            set => Set(ref _toggleState, value);
        }

        private string _inputData = "Введите текст здесь";
        public string InputData
        {
            get => _inputData;
            set => Set(ref _inputData, value);
        }

        private readonly string _staticData = "Статические данные: " + DateTime.Now.ToString("dd.MM.yyyy");
        public string StaticData => _staticData;

        public ObservableCollection<string> DataList { get; } = new ObservableCollection<string>();

        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??= new RelayCommand(() =>
        {
            DisplayText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
            NumericValue = new Random().Next(0, 100);
        });

        private RelayCommand _resetCommand;
        public RelayCommand ResetCommand => _resetCommand ??= new RelayCommand(() =>
        {
            InputData = "";
            DisplayText = "Сброшено";
        });

        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand => _addItemCommand ??= new RelayCommand(() =>
        {
            DataList.Add($"Запись #{DataList.Count + 1}");
        });

        public MainViewModel()
        {
            DataList.Add("Пример данных 1");
            DataList.Add("Пример данных 2");
            DataList.Add("Пример данных 3");
        }

        public string CurrentDateTime => DateTime.Now.ToString("dd.MM.yyyy HH:mm");
    }
}