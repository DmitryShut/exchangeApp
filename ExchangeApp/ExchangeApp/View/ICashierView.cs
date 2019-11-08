using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.View
{
    public interface ICashierView
    { 
        User GetCashier();
        event Delegates.SetCashier SetCashier;
        event Delegates.GetCurrencies GetCurrencies;
        void UpdateCurrencies(List<Currency> currencies);
    }
    
    public static class Delegates
    {
        public delegate void SetCashier(User cashier);
        public delegate void GetCurrencies();
    }
}