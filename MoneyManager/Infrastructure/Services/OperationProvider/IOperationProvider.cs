using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationProvider
{
    public interface IOperationProvider
    {
        Task<IEnumerable<Operation>> GetAllOperations();
    }
}
