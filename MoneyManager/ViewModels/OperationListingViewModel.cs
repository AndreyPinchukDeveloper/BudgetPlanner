using MoneyManager.Infrastructure.Commands;
using MoneyManager.Infrastructure.Services;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.Models;
using MoneyManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.ViewModels
{
    public class OperationListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<OperationViewModel> _operations;
        private readonly AllOperationsStore _allOperationsStore;//check here
        public IEnumerable<OperationViewModel> Reservations => _operations;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }


        public ICommand LoadOperationsCommand { get; }
        public ICommand MakeOperationCommand { get; }

        public OperationListingViewModel(
            AllOperationsStore allOperationsStore,
            MyNavigationService<MakeOperationViewModel> makeReservationNavigationService)
        {
            _allOperationsStore = allOperationsStore;
            _operations = new ObservableCollection<OperationViewModel>();

            LoadOperationsCommand = new LoadOperationCommand(this, allOperationsStore);
            MakeOperationCommand = new NavigateCommand<MakeOperationViewModel>(makeReservationNavigationService);
            _allOperationsStore.OperationMade += OnOperationMade;//subscribe
        }

        /// <summary>
        /// Unsubscribe event
        /// </summary>
        public override void Dispose()
        {
            _allOperationsStore.OperationMade -= OnOperationMade;
            base.Dispose();
        }

        private void OnOperationMade(Operation operation)
        {
            OperationViewModel operationViewModel = new OperationViewModel(operation);
            _operations.Add(operationViewModel);
        }

        public static OperationListingViewModel LoadViewModel(
            AllOperationsStore allOperationsStore,
            MyNavigationService<MakeOperationViewModel> makeReservationNavigationService)
        {
            OperationListingViewModel viewModel = new OperationListingViewModel(allOperationsStore, makeReservationNavigationService);
            viewModel.LoadOperationsCommand.Execute(null);
            return viewModel;
        }

        public void UpdateOperations(IEnumerable<Operation> operations)
        {
            _operations.Clear();

            foreach (Operation operation in operations)
            {
                OperationViewModel reservationViewModel = new OperationViewModel(operation);
                _operations.Add(reservationViewModel);
            }
        }
    }
}
