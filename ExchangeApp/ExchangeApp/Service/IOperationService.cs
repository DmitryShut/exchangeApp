using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Model.Implementations
{
    public interface IOperationService
    {
        BigInteger PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount,
            User user, OperationType operationType, User cashier);

        List<Operation> GetOperations();

        List<Operation> FilterOperations(string filter);

        List<Operation> GetOperations(string filter);

        event ServiceDelegates.UpdateOperations UpdateOperations;
    }
}