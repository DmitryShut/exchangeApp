using System.Collections.Generic;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Presenter
{
    public interface ICashierPresenter
    {
        User GetCashier();
        void SetCashier(User cashier);
        void GetCurrencies();
        void BuyCurrency(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user);
    }
}