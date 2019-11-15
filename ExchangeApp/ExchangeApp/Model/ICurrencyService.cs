using System.Collections.Generic;
using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface ICurrencyService
    {

        List<Currency> GetCurrencies();

        void addCurrency(Currency currency);
    }
}