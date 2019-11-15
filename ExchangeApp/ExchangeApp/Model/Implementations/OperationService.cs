using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model.Implementations
{
    public class OperationService : IOperationService
    {
        public List<Operation> operations = new List<Operation>();

        public void SetOperation(Operation operation)
        {
            operations.Add(operation);
            UpdateOperations?.Invoke();
        }

        public List<Operation> GetOperations()
        {
            return operations;
        }

        public event Delegates.UpdateOperations UpdateOperations;
    }
}