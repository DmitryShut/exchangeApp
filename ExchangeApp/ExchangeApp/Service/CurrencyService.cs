using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;
using ExchangeApp.Repository;

namespace ExchangeApp.Model.Implementations
{
    public class CurrencyService: ICurrencyService
    {
        public IRepository<Currency> currencyRepository;

        public CurrencyService(IRepository<Currency> currencyRepository)
        {
            this.currencyRepository = currencyRepository;
            this.currencyRepository.Create(new Currency("A", new BigInteger(123), new BigInteger(123), new BigInteger(123), new BigInteger(12)));
            this.currencyRepository.Create(new Currency("B", new BigInteger(123), new BigInteger(123), new BigInteger(123), new BigInteger(12)));
            this.currencyRepository.Create(new Currency("C", new BigInteger(123), new BigInteger(123), new BigInteger(123), new BigInteger(12)));
        }

        public List<Currency> GetCurrencies()
        {
            return currencyRepository.FindAll();
        }

        public event ServiceDelegates.UpdateCurrencies UpdateCurrencies;
        
        public void addCurrency(Currency currency)
        {
            currencyRepository.Create(currency);
            UpdateCurrencies?.Invoke();
        }
        
        public void UpdateCurrency(Currency currency)
        {
            currencyRepository.Update(currency);
            UpdateCurrencies?.Invoke();
        }
    }
}