using System.Collections.Generic;
using ExchangeApp.Entity;
using ExchangeApp.Repository;

namespace ExchangeApp.Model.Implementations
{
    public class OperationService
    {
        public IRepository<Operation, long> operationRepository;

        public OperationService(IRepository<Operation, long> operationRepository)
        {
            this.operationRepository = operationRepository;
        }

        public void SetOperation(Operation operation)
        {
            operationRepository.Create(operation, operation.Date);
            UpdateOperations?.Invoke();
        }

        public List<Operation> GetOperations()
        {
            return operationRepository.FindAll();
        }

        public event ServiceDelegates.UpdateOperations UpdateOperations;
    }
}