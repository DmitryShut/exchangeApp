using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public class ViewDelegates
    {
        public delegate void GetCurrencies();

        public delegate void AddCurrency(Currency currency);

        public delegate void PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount,
            User user, OperationType operationType, User cashier);
    }
}