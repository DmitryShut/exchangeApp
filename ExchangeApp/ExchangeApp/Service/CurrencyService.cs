using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;
using ExchangeApp.Repository;

namespace ExchangeApp.Model.Implementations
{
    public class CurrencyService
    {
        public IRepository<Currency, string> currencyRepository;

        public CurrencyService(IRepository<Currency, string> currencyRepository)
        {
            this.currencyRepository = currencyRepository;
            currencyRepository.Create(new Currency("USD", new BigInteger(21321), new BigInteger(213),new BigInteger(456546), new BigInteger(324)), "USD");
            currencyRepository.Create(new Currency("EUR", new BigInteger(2132), new BigInteger(213123),new BigInteger(234), new BigInteger(78978)), "EUR");
            currencyRepository.Create(new Currency("BYN", new BigInteger(435), new BigInteger(456),new BigInteger(567), new BigInteger(123)), "BYN");
            currencyRepository.Create(new Currency("RUB", new BigInteger(657), new BigInteger(234),new BigInteger(23214), new BigInteger(345)), "RUB");
        }

        public List<Currency> GetCurrencies()
        {
            return currencyRepository.FindAll();
        }

        public event ServiceDelegates.UpdateCurrencies UpdateCurrencies;
        
        public void addCurrency(Currency currency)
        {
            currencyRepository.Create(currency, currency.CurrencyName);
            UpdateCurrencies?.Invoke();
        }
    }
}