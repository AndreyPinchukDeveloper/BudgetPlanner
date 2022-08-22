using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.DbContexts;
using MoneyManager.Infrastructure.DTOs;
using MoneyManager.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationConflictValidator
{
    internal class DatabaseOperationConflictValidator:IOperationConflictValidator
    {
        private readonly MoneyManagerDbContextFactory _dbContextFactory;

        public DatabaseOperationConflictValidator(MoneyManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Operation> GetConflictOperation(Operation operation)
        {
            using (MoneyManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                OperationDTO operationDTO = await context.Operations
                    .Where(r => r.AmountOfMoney == operation.AmountOfMoney)
                    .Where(r => r.TypeOfOperation == operation.TypeOfOperation)
                    .Where(r => r.TimeOfChange == operation.TimeOfChange)
                    .Where(r => r.Categories == operation.Categories)
                    .Where(r => r.Note == operation.Note)
                    .FirstOrDefaultAsync();

                if (operationDTO == null)
                {
                    return null;
                }

                return ToOperation(operationDTO);
            }
        }

        private Operation ToOperation(OperationDTO dto)
        {
            return new Operation(dto.AmountOfMoney, dto.TypeOfOperation, dto.TimeOfChange, dto.Categories, dto.Note);
        }
    }
}
