using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface IExchangeService
    {
        Money Exchange(Money fromMoney, Currency toCurrency, OperationType operationType);
    }
}