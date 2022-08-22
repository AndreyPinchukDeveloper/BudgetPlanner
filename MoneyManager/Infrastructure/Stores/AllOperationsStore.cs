using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Stores
{
    public class AllOperationsStore
    {
        private readonly AllOperations _allOperations;
        private readonly List<Operation> _operations;
        private Lazy<Task> _initializeLazy;//we use lazy initialization to create an object only when 
                                           //we first call it
        public IEnumerable<Operation> Operations => _operations;
        public event Action<Operation> OperationMade;//Action return void, Func return value

        public AllOperationsStore(AllOperations allOperations)
        {
            _allOperations = allOperations;
            _initializeLazy = new Lazy<Task>(Initialize);

            _operations = new List<Operation>();
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }


        }

        public async Task MakeOperation(Operation operation)
        {
            await _allOperations.MakeOperation(operation);
            _operations.Add(operation);

            OnOperationMade(operation);
        }

        /// <summary>
        /// Invoke method for Action delegate
        /// </summary>
        private void OnOperationMade(Operation operation)
        {
            OperationMade?.Invoke(operation);
        }

        private async Task Initialize()
        {
            IEnumerable<Operation> reservations = await _allOperations.GetAllReservations();

            _operations.Clear();
            _operations.AddRange(reservations);
        }
    }
}
