using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationCreator
{
    public interface IOperationCreator
    {
        Task CreateOperation(Operation operation);
    }
}
