using MoneyManager.Infrastructure.DbContexts;
using MoneyManager.Infrastructure.DTOs;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationCreator
{
    public class DatabaseOperationCreator:IOperationCreator
    {
        private readonly MoneyManagerDbContextFactory _dbContextFactory;

        public DatabaseOperationCreator(MoneyManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateOperation(Operation operation)
        {
            using (MoneyManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                OperationDTO operationDTO = ToOperationDTO(operation);

                context.Operations.Add(operationDTO);
                await context.SaveChangesAsync();
            }
        }

        private OperationDTO ToOperationDTO(Operation operation)
        {
            return new OperationDTO()
            {
                AmountOfMoney = operation.AmountOfMoney,
                TypeOfOperation = operation.TypeOfOperation,
                TimeOfChange = operation.TimeOfChange,
                Categories = operation.Categories,
                Note = operation.Note,
            };
        }

    }
}
