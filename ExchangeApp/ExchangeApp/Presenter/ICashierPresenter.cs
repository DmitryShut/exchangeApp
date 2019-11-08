using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Presenter
{
    public interface ICashierPresenter
    {
        User GetCashier();
        void SetCashier(User cashier);

        void GetCurrencies();
    }
}