using MoneyManager.Infrastructure.Exceptions;
using MoneyManager.Infrastructure.Services.OperationConflictValidator;
using MoneyManager.Infrastructure.Services.OperationCreator;
using MoneyManager.Infrastructure.Services.OperationProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class OperationBook
    {
        private readonly IOperationProvider _operationProvider;
        private readonly IOperationCreator _operationCreator;
        private readonly IOperationConflictValidator _operationConflictValidator;

        public OperationBook(IOperationProvider operationProvider, IOperationCreator operationCreator, IOperationConflictValidator operationConflictValidator)
        {
            _operationProvider = operationProvider;
            _operationCreator = operationCreator;
            _operationConflictValidator = operationConflictValidator;
        }

        /// <summary>
        /// Get all operations
        /// </summary>
        public async Task<IEnumerable<Operation>> GetAllReservations()
        {
            return await _operationProvider.GetAllOperations();
        }

        /// <summary>
        /// Make new operation
        /// </summary>
        public async Task AddOperation(Operation operation)
        {
            Operation conflictReservation = await _operationConflictValidator.GetConflictOperation(operation);

            if (conflictReservation != null)
            {
                throw new OperationsConflictException(conflictReservation, operation);
            }
            await _operationCreator.CreateOperation(operation);
        }
    }
}
