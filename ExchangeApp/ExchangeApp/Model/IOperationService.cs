using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface IOperationService
    {
        void SetOperation(Operation operation);
        List<Operation> GetOperations();
    }
}