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