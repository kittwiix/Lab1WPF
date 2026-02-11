using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfK
{
    /// <summary>Базовый ViewModel на основе ObservableObject из CommunityToolkit.Mvvm.</summary>
    public abstract class ViewModelBase : ObservableObject
    {
        /// <summary>Обёртка над SetProperty Toolkit для совместимости с веткой master.</summary>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(ref field, value, propertyName);
        }
    }
}