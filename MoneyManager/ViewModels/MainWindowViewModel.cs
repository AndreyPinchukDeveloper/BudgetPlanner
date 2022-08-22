using MoneyManager.Infrastructure.Commands;
using MoneyManager.Infrastructure.Services;
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
    public class MainWindowViewModel:ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public ICommand OpenAccountController { get;}
        public ICommand OpenOperationController { get; }
        public ICommand OpenHistoryController { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new MyAccountViewModel();
        }
        /*public MainWindowViewModel(MyNavigationService<OperationListingViewModel> operationViewNavigationService)
        {
            
            OpenAccountController = new NavigateCommand<OperationListingViewModel>(operationViewNavigationService);
        }*/
    }
}
