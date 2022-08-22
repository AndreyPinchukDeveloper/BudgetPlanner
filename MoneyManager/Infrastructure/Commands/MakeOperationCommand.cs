using MoneyManager.Infrastructure.Commands.Base;
using MoneyManager.Infrastructure.Exceptions;
using MoneyManager.Infrastructure.Services;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.Models;
using MoneyManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyManager.Infrastructure.Commands
{
    public class MakeOperationCommand : AsyncCommanBase
    {
        private readonly MakeOperationViewModel _makeOperationViewModel;
        private readonly AllOperationsStore _allOperationsStore;
        private readonly MyNavigationService<OperationListingViewModel> _operationViewNavigationService;

        public MakeOperationCommand(
            MakeOperationViewModel makeResrvationViewModel,
            AllOperationsStore hotelStore,
            MyNavigationService<OperationListingViewModel> operationViewNavigationService)
        {
            _makeOperationViewModel = makeResrvationViewModel;
            _allOperationsStore = hotelStore;
            _operationViewNavigationService = operationViewNavigationService;

            _makeOperationViewModel.PropertyChanged += OnViewModelPropertyChanged;//subscribe to propertyChnaged on our ViewModel
        }

        /// <summary>
        /// We come here while enter our amount of money for change
        /// </summary>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeOperationViewModel.AmountOfMoney))
            {
                OnCanExecuteChanged();
            }
        }

        /// <summary>
        /// If amountOfMoney null or empty Accept button isn't available
        /// </summary>
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeOperationViewModel.AmountOfMoney)&&
                base.CanExecute(parameter);
        }

        /// <summary>
        /// Create a new operation and show user information about it
        /// </summary>
        public override async Task ExecuteAsync(object parameter)
        {
            Operation operation = new Operation(
                _makeOperationViewModel.AmountOfMoney,
                _makeOperationViewModel.TypeOfOperation,
                _makeOperationViewModel.TimeOfChange,
                _makeOperationViewModel.Categories,
                _makeOperationViewModel.Note
                );
            try
            {
                await _allOperationsStore.MakeOperation(operation);
                MessageBox.Show("Successfully made operation.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _operationViewNavigationService.Navigate();
            }
            catch (OperationsConflictException)
            {
                MessageBox.Show("This room is already taken. Please, choice another one.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to make reservation.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
