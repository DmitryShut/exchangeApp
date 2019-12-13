using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model.Implementations
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();

        event ServiceDelegates.UpdateCurrencies UpdateCurrencies;

        void addCurrency(Currency currency);
    }
}