using MoneyManager.Infrastructure.Commands;
using MoneyManager.Infrastructure.Services;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.ViewModels
{
    public class MakeOperationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        #region TextBoxView

        #region FodyRegion
        public string AmountOfMoney { get; set; }
        public string TypeOfOperation { get; set; }
        public DateTime TimeOfChange { get; set; }
        public string Categories { get; set; }
        public string Note { get; set; }
        #endregion

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }
            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        public ICommand ClearCommand { get; }

        #endregion

        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        /// <summary>
        /// We initializeour commands in this constructor
        /// </summary>
        public MakeOperationViewModel(AllOperationsStore allOperationsStore, MyNavigationService<OperationListingViewModel> reservationViewNavigationService)
        {
            SubmitCommand = new MakeOperationCommand(this, allOperationsStore, reservationViewNavigationService);
            ClearCommand = new NavigateCommand<OperationListingViewModel>(reservationViewNavigationService);

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}
