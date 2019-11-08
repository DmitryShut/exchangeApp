using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface ICurrencyService
    {
        Currency GetCurrency(string currencyName);

        List<Currency> GetCurrencies();
    }
}