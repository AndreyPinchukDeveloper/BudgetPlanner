using MoneyManager.Models;
using System;
using System.Runtime.Serialization;

namespace MoneyManager.Infrastructure.Exceptions
{
    public class OperationsConflictException:Exception
    {
        public Operation ExistingOperation { get; }
        public Operation IncomeOperation { get; }

        public OperationsConflictException(Operation existingOperation = null, Operation incomeOperation = null)
        {
            ExistingOperation = existingOperation;
            IncomeOperation = incomeOperation;
        }

        public OperationsConflictException(string message, Operation existingOperation, Operation incomeOperation) : base(message)
        {
            ExistingOperation = existingOperation;
            IncomeOperation = incomeOperation;
        }

        public OperationsConflictException(string message, Exception innerException, Operation existingOperation, Operation incomeOperation) : base(message, innerException)
        {
            ExistingOperation = existingOperation;
            IncomeOperation = incomeOperation;
        }

        protected OperationsConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
