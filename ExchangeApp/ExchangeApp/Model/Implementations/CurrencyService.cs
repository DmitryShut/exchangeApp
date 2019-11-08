using System;
using System.Collections.Generic;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Model.Implementations
{
    public class CurrencyService: ICurrencyService
    {

        private Dictionary<string, Currency> _currencies = new Dictionary<string, Currency>
        {
            {"USD", new Currency("USD", 1000, 1000, 21312, 123413)},
            {"EUR", new Currency("EUR", 100, 120, 21312, 123413)},
            {"PLN", new Currency("PLN", new BigInteger(2.3), 3, 21312, 123413)}
        };
        
        public Currency GetCurrency(string currencyName)
        {
            return _currencies[currencyName];
        }

        public List<Currency> GetCurrencies()
        {
            return new List<Currency>(_currencies.Values);
        }
    }
}