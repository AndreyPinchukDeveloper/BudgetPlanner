using System.ComponentModel;

namespace MoneyManager.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method is serving to tell UI what bindings is update
        /// </summary>
        protected void OnPropertyChanged(string propertyName)//only for inheritors
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Dispose use to delete unmanage resources
        /// </summary>
        public virtual void Dispose() { }
    }
}
