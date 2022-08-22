using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.DbContexts;
using MoneyManager.Infrastructure.DTOs;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Services.OperationProvider
{
    public class DatabaseOperationProvider:IOperationProvider
    {
        private readonly MoneyManagerDbContextFactory _dbContextFactory;

        public DatabaseOperationProvider(MoneyManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Operation>> GetAllOperations()//Класс Task представляет собой одну операцию, которая не возвращает значение и обычно выполняется асинхронно.
                                                                        //Task объекты являются одним из центральных компонентов асинхронного шаблона на основе задач
        {
            using (MoneyManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<OperationDTO> operationDTOs = await context.Operations.ToListAsync();

                await Task.Delay(2000);

                return operationDTOs.Select(r => ToOperation(r));
            }
        }

        private static Operation ToOperation(OperationDTO dto)
        {
            return new Operation(dto.AmountOfMoney, dto.TypeOfOperation, dto.TimeOfChange, dto.Categories, dto.Note);
        }
    }
}
