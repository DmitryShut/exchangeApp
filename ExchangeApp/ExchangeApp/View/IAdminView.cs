using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public interface IAdminView
    {
        event Delegates.GetCurrencies GetCurrencies;
        event Delegates.AddCurrency AddCurrency;
        void UpdateCurrencies(List<Currency> currencies);
        void UpdateOperations(List<Operation> operations);
    }
}