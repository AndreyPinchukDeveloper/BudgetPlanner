using MoneyManager.Models;
using MoneyManager.ViewModels.Base;

namespace MoneyManager.ViewModels
{
    public class OperationViewModel : ViewModelBase
    {
        private readonly Operation _operation;
        public string AmountOfMoney => _operation.AmountOfMoney.ToString();
        public string TypeOfOperation => _operation.TypeOfOperation;
        public string TimeOfChange => _operation.TimeOfChange.ToString("d");
        public string Categories => _operation.Categories.ToString();
        public string Note => _operation.Note.ToString();
        public OperationViewModel(Operation operation)
        {
            _operation = operation;
        }
    }
}
