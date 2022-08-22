using MoneyManager.Infrastructure.Commands.Base;
using MoneyManager.Infrastructure.Stores;
using MoneyManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Commands
{
    public class LoadOperationCommand : AsyncCommanBase
    {
        private readonly OperationListingViewModel _viewModel;
        private readonly AllOperationsStore _allOperationStore;

        public LoadOperationCommand(OperationListingViewModel reservationListingViewModel, AllOperationsStore allOperationStore)//check here if something came up
        {
            _viewModel = reservationListingViewModel;
            _allOperationStore = allOperationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;
            _viewModel.IsLoading = true;

            try
            {
                await _allOperationStore.Load();

                _viewModel.UpdateOperations(_allOperationStore.Operations);
            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "Failed to load reservations.";
            }
            _viewModel.IsLoading = false;
        }
    }
}
