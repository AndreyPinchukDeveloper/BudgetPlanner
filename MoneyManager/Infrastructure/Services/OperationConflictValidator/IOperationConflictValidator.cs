using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationConflictValidator
{
    public interface IOperationConflictValidator
    {
        Task<Operation> GetConflictOperation(Operation operation);
    }
}
