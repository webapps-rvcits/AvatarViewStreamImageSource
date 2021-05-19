using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;

namespace AvatarView.ViewModel
{
    public class BaseViewModel
    {
        #region INotifyPropertyChanged
        readonly DelegateWeakEventManager PropertyChangedEventManager = new DelegateWeakEventManager();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => PropertyChangedEventManager.AddEventHandler(value);
            remove => PropertyChangedEventManager.RemoveEventHandler(value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChangedEventManager;
            if (changed == null)
                return;

            changed.RaiseEvent(this, new PropertyChangedEventArgs(propertyName), nameof(PropertyChanged));
        }
        #endregion
    }
}
