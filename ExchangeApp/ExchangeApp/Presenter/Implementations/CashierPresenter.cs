using System;
using System.Collections.Generic;
using System.Numerics;
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
        private readonly IOperationService _operationService;

        public CashierPresenter(ICashierService cashierService, ICashierView cashierView, ICurrencyService currencyService, IOperationService operationService)
        {
            _cashierService = cashierService;
            _cashierView = cashierView;
            _currencyService = currencyService;
            _operationService = operationService;

            _cashierView.SetCashier += SetCashier;
            _cashierView.GetCurrencies += GetCurrencies;
            _cashierView.BuyCurrency += BuyCurrency;
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

        public void BuyCurrency(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user)
        {
            BigInteger targetAmount = userAmount * targetCurrency.PurchaseRate / userCurrency.SellingRate;
            _cashierView.SetTargetCurrency(targetAmount);
            _operationService.SetOperation(new Operation(DateTime.Now, user, OperationType.Purchase, userCurrency, userAmount, targetCurrency, targetAmount));
        }
    }
}