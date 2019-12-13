using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Presenter.Implementations
{
    public interface ICashierPresenter
    {
        void GetCurrencies();

        void PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user,
            OperationType operationType, User cashier);

    }
}