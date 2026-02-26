using System;
using System.ComponentModel;
using System.Globalization;
using WpfK.Properties;

namespace WpfK
{
    /// <summary>Менеджер локализации на основе RESX. Поддерживает динамическое переключение языка.</summary>
    public sealed class LocalizationManager : INotifyPropertyChanged
    {
        public static LocalizationManager Instance { get; } = new LocalizationManager();

        private CultureInfo _currentCulture = new CultureInfo("ru");

        public event PropertyChangedEventHandler? PropertyChanged;

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Name == value?.Name)
                    return;
                _currentCulture = value ?? new CultureInfo("ru");
                OnAllPropertiesChanged();
            }
        }

        public string WindowTitle => GetString(nameof(WindowTitle));
        public string TabDefaultBinding => GetString(nameof(TabDefaultBinding));
        public string TabTwoWayBinding => GetString(nameof(TabTwoWayBinding));
        public string LabelLanguage => GetString(nameof(LabelLanguage));
        public string HeaderWindowTitle => GetString(nameof(HeaderWindowTitle));
        public string HeaderSync => GetString(nameof(HeaderSync));
        public string HeaderProgress => GetString(nameof(HeaderProgress));
        public string HeaderState => GetString(nameof(HeaderState));
        public string HeaderLaunchTime => GetString(nameof(HeaderLaunchTime));
        public string HeaderReadOnly => GetString(nameof(HeaderReadOnly));
        public string HeaderDataList => GetString(nameof(HeaderDataList));
        public string GridViewValue => GetString(nameof(GridViewValue));
        public string BtnRefresh => GetString(nameof(BtnRefresh));
        public string BtnSwitch => GetString(nameof(BtnSwitch));
        public string BtnReset => GetString(nameof(BtnReset));
        public string BtnAddRecord => GetString(nameof(BtnAddRecord));
        public string DefaultBindingTitle => GetString(nameof(DefaultBindingTitle));
        public string DefaultBindingText1 => GetString(nameof(DefaultBindingText1));
        public string DefaultBindingText2 => GetString(nameof(DefaultBindingText2));
        public string DefaultBindingText3 => GetString(nameof(DefaultBindingText3));
        public string TwoWayBindingTitle => GetString(nameof(TwoWayBindingTitle));
        public string Example1Title => GetString(nameof(Example1Title));
        public string Example1Desc => GetString(nameof(Example1Desc));
        public string Field1VM => GetString(nameof(Field1VM));
        public string Field2VM => GetString(nameof(Field2VM));
        public string CurrentValueVM => GetString(nameof(CurrentValueVM));
        public string Example1bTitle => GetString(nameof(Example1bTitle));
        public string Example1bDesc => GetString(nameof(Example1bDesc));
        public string Field1Direct => GetString(nameof(Field1Direct));
        public string Field2Bound => GetString(nameof(Field2Bound));
        public string DirectBindingText => GetString(nameof(DirectBindingText));
        public string Example2Title => GetString(nameof(Example2Title));
        public string CheckBoxOption => GetString(nameof(CheckBoxOption));
        public string StateFormat => GetString(nameof(StateFormat));
        public string BtnToggleVM => GetString(nameof(BtnToggleVM));
        public string Example3Title => GetString(nameof(Example3Title));
        public string LabelValue => GetString(nameof(LabelValue));
        public string CurrentValueFormat => GetString(nameof(CurrentValueFormat));
        public string TwoWayHowTitle => GetString(nameof(TwoWayHowTitle));
        public string TwoWayHow1 => GetString(nameof(TwoWayHow1));
        public string TwoWayHow2 => GetString(nameof(TwoWayHow2));
        public string TwoWayHow3 => GetString(nameof(TwoWayHow3));
        public string TwoWayHow4 => GetString(nameof(TwoWayHow4));
        public string TwoWayHow5 => GetString(nameof(TwoWayHow5));
        public string MsgMaxRecords => GetString(nameof(MsgMaxRecords));
        public string MsgWarning => GetString(nameof(MsgWarning));
        public string MsgError => GetString(nameof(MsgError));
        public string MsgRecordAdded => GetString(nameof(MsgRecordAdded));
        public string MsgSuccess => GetString(nameof(MsgSuccess));

        private LocalizationManager() { }

        public string GetString(string key)
        {
            try
            {
                var result = Resources.ResourceManager.GetString(key, _currentCulture) ?? Resources.ResourceManager.GetString(key, new CultureInfo("ru")) ?? key;
                return result ?? string.Empty;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager.GetString('{key}'): {ex.Message}");
                return key;
            }
        }

        public string GetString(string key, params object[] args)
        {
            try
            {
                var format = GetString(key);
                return string.Format(_currentCulture, format, args);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocalizationManager.GetString('{key}'): {ex.Message}");
                return key;
            }
        }

        private void OnAllPropertiesChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        public void SetCulture(string cultureName)
        {
            CurrentCulture = new CultureInfo(cultureName);
        }
    }
}
