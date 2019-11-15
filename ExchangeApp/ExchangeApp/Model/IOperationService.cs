using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface IOperationService
    {
        void SetOperation(Operation operation);
        List<Operation> GetOperations();

        event Delegates.UpdateOperations UpdateOperations;
    }

    public static class Delegates
    {
        public delegate void UpdateOperations();
    }
}