using System;
using System.Collections.Generic;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public interface ICashierView
    {
        void SetupForm(object sender, EventArgs e);

        event ViewDelegates.GetCurrencies GetCurrencies;
        event ViewDelegates.PerformOperation PerformOperation;

        void InputCashier(object sender, EventArgs e);

        void UpdateCurrencies(List<Currency> Currencies);

        void SetTargetCurrency(BigInteger targetCurrency);

        void Buy(object sender, EventArgs e);

        void Sell(object sender, EventArgs e);

        void showMessageBox(string message);

        void GetBill(object sender, EventArgs e);
    }
}