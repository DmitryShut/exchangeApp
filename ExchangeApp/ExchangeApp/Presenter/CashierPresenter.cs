using System;
using System.Collections.Generic;
using System.Numerics;
using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.View;

namespace ExchangeApp.Presenter.Implementations
{
    public class CashierPresenter
    {
        private readonly CashierView _cashierView;
        private readonly CurrencyService _currencyService;
        private readonly OperationService _operationService;

        public CashierPresenter(CashierView cashierView, CurrencyService currencyService,
            OperationService operationService)
        {
            _cashierView = cashierView;
            _currencyService = currencyService;
            _operationService = operationService;

            _cashierView.GetCurrencies += GetCurrencies;
            _cashierView.PerformOperation += PerformOperation;
            _currencyService.UpdateCurrencies += GetCurrencies;
        }

        public void GetCurrencies()
        {
            _cashierView.UpdateCurrencies(_currencyService.GetCurrencies());
        }

        public void PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user, OperationType operationType, User cashier)
        {
            if (operationType.Equals(OperationType.Purchase))
            {
                BigInteger targetAmount = userAmount * targetCurrency.PurchaseRate / userCurrency.SellingRate;
                _cashierView.SetTargetCurrency(targetAmount);
                _operationService.SetOperation(new Operation(DateTimeOffset.Now.ToUnixTimeMilliseconds(), user, OperationType.Purchase, userCurrency,
                    userAmount, targetCurrency, targetAmount, cashier));
            }
            else
            {
                BigInteger targetAmount = userAmount * targetCurrency.SellingRate / userCurrency.PurchaseRate;
                _cashierView.SetTargetCurrency(targetAmount);
                _operationService.SetOperation(new Operation(DateTimeOffset.Now.ToUnixTimeMilliseconds(), user, OperationType.Selling, userCurrency,
                    userAmount, targetCurrency, targetAmount, cashier));
            }
        }
    }
}