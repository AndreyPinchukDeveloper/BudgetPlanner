using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    /// <summary>
    /// Main model class
    /// </summary>
    public class Operation
    {
        public string AmountOfMoney { get; }
        public string TypeOfOperation { get; }
        public DateTime TimeOfChange { get; }
        public string Categories { get; }
        public string Note { get; }
        public Operation(string amountOfMoney, string typeOfOperation, DateTime timeOfChange, string categories, string note)
        {
            AmountOfMoney = amountOfMoney;
            TypeOfOperation = typeOfOperation;
            TimeOfChange = timeOfChange;
            Categories = categories;
            Note = note;
        }
    }
}
