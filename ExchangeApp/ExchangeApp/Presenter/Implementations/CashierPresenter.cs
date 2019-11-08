using System.Collections.Generic;
using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.View;

namespace ExchangeApp.Presenter.Implementations
{
    public class CashierPresenter: ICashierPresenter
    {
        private readonly ICashierService _cashierService;
        private readonly ICashierView _cashierView;
        private readonly ICurrencyService _currencyService;

        public CashierPresenter(ICashierService cashierService, ICashierView cashierView, ICurrencyService currencyService)
        {
            _cashierService = cashierService;
            _cashierView = cashierView;
            _currencyService = currencyService;
            
            _cashierView.SetCashier += SetCashier;
            _cashierView.GetCurrencies += GetCurrencies;
        }


        public User GetCashier()
        {
            throw new System.NotImplementedException();
        }

        public void SetCashier(User cashier)
        {
            _cashierService.SetCashier(cashier);
        }

        public void GetCurrencies()
        {
            _cashierView.UpdateCurrencies(_currencyService.GetCurrencies());
        }
    }
}