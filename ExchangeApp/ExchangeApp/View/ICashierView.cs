using System.Collections.Generic;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public interface ICashierView
    { 
        User GetCashier();
        event Delegates.SetCashier SetCashier;
        event Delegates.GetCurrencies GetCurrencies;
        event Delegates.BuyCurrency BuyCurrency;
        event Delegates.SellCurrency SellCurrency;
        void UpdateCurrencies(List<Currency> currencies);

        void SetTargetCurrency(BigInteger targetCurrency);
    }
    
    public static class Delegates
    {
        public delegate void SetCashier(User cashier);
        public delegate void GetCurrencies();
        public delegate void AddCurrency(Currency currency);
        public delegate void BuyCurrency(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user);
        public delegate void SellCurrency(Currency userCurrency, Currency targetCurrency, BigInteger userAmount, User user);
    }
}