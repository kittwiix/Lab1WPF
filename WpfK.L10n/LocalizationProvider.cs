using System;
using System.ComponentModel;

namespace WpfK.L10n
{
    /// <summary>Провайдер локализации — единственная точка доступа к строкам внешней библиотеки.</summary>
    public sealed class LocalizationProvider : INotifyPropertyChanged
    {
        public static LocalizationProvider Instance { get; } = new LocalizationProvider();

        private IReadOnlyDictionary<string, string> _current = Strings.Ru;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string CurrentCulture { get; private set; } = "ru";

        public string WindowTitle => GetString("WindowTitle");
        public string TabDefaultBinding => GetString("TabDefaultBinding");
        public string TabTwoWayBinding => GetString("TabTwoWayBinding");
        public string LabelLanguage => GetString("LabelLanguage");
        public string HeaderWindowTitle => GetString("HeaderWindowTitle");
        public string HeaderSync => GetString("HeaderSync");
        public string HeaderProgress => GetString("HeaderProgress");
        public string HeaderState => GetString("HeaderState");
        public string HeaderLaunchTime => GetString("HeaderLaunchTime");
        public string HeaderReadOnly => GetString("HeaderReadOnly");
        public string HeaderDataList => GetString("HeaderDataList");
        public string GridViewValue => GetString("GridViewValue");
        public string BtnRefresh => GetString("BtnRefresh");
        public string BtnSwitch => GetString("BtnSwitch");
        public string BtnReset => GetString("BtnReset");
        public string BtnAddRecord => GetString("BtnAddRecord");
        public string DefaultBindingTitle => GetString("DefaultBindingTitle");
        public string DefaultBindingText1 => GetString("DefaultBindingText1");
        public string DefaultBindingText2 => GetString("DefaultBindingText2");
        public string DefaultBindingText3 => GetString("DefaultBindingText3");
        public string TwoWayBindingTitle => GetString("TwoWayBindingTitle");
        public string Example1Title => GetString("Example1Title");
        public string Example1Desc => GetString("Example1Desc");
        public string Field1VM => GetString("Field1VM");
        public string Field2VM => GetString("Field2VM");
        public string CurrentValueVM => GetString("CurrentValueVM");
        public string Example1bTitle => GetString("Example1bTitle");
        public string Example1bDesc => GetString("Example1bDesc");
        public string Field1Direct => GetString("Field1Direct");
        public string Field2Bound => GetString("Field2Bound");
        public string DirectBindingText => GetString("DirectBindingText");
        public string Example2Title => GetString("Example2Title");
        public string CheckBoxOption => GetString("CheckBoxOption");
        public string StateFormat => GetString("StateFormat");
        public string BtnToggleVM => GetString("BtnToggleVM");
        public string Example3Title => GetString("Example3Title");
        public string LabelValue => GetString("LabelValue");
        public string CurrentValueFormat => GetString("CurrentValueFormat");
        public string TwoWayHowTitle => GetString("TwoWayHowTitle");
        public string TwoWayHow1 => GetString("TwoWayHow1");
        public string TwoWayHow2 => GetString("TwoWayHow2");
        public string TwoWayHow3 => GetString("TwoWayHow3");
        public string TwoWayHow4 => GetString("TwoWayHow4");
        public string TwoWayHow5 => GetString("TwoWayHow5");
        public string MsgMaxRecords => GetString("MsgMaxRecords");
        public string MsgWarning => GetString("MsgWarning");
        public string MsgError => GetString("MsgError");
        public string MsgRecordAdded => GetString("MsgRecordAdded");
        public string MsgSuccess => GetString("MsgSuccess");

        private LocalizationProvider() { }

        public string GetString(string key)
        {
            return _current.TryGetValue(key, out var value) ? value : key;
        }

        public string GetString(string key, params object[] args)
        {
            var format = GetString(key);
            return string.Format(format, args);
        }

        public void SetCulture(string cultureName)
        {
            if (CurrentCulture == cultureName)
                return;

            _current = cultureName == "en" ? Strings.En : Strings.Ru;
            CurrentCulture = cultureName;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
