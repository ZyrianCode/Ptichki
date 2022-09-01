using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMEssentials.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> Items { get; set; }
        public ObservableCollection<object> ObservableCollection { get; set; }

        #region LoadingFieldsRegion

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        #endregion

        #region LoadingErrorsRegion

        public bool HasLoadingErrorMessage =>
            !string.IsNullOrEmpty(LoadingError);

        private string _loadingError;
        public string LoadingError
        {
            get => _loadingError;
            set
            {
                _loadingError = value;
                OnPropertyChanged(nameof(LoadingError));

                OnPropertyChanged(nameof(HasLoadingErrorMessage));
            }
        }

        #endregion
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Разрешает проблему кольцевых обновлений свойств
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return true;
            field = value;
            OnPropertyChanged(nameof(propertyName));
            return true;
        }

        public virtual void UpdateCollections(IEnumerable<object> collection) =>
            Items = collection;

        public virtual void UpdateFields() { }
        public virtual void Dispose() { }
    }
}
