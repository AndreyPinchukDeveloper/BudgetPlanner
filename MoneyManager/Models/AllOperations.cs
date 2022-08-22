using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class AllOperations
    {
        private readonly OperationBook _operationBook;

        public AllOperations(OperationBook operationBook)
        {
            _operationBook = operationBook;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        public async Task<IEnumerable<Operation>> GetAllReservations()
        {
            return await _operationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation.
        /// </summary>
        public async Task MakeOperation(Operation operation)
        {
            await _operationBook.AddOperation(operation);
        }
    }
}
