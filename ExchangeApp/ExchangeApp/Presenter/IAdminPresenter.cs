using ExchangeApp.Entity;

namespace ExchangeApp.Presenter
{
    public interface IAdminPresenter
    {
        void GetCurrencies();

        void AddCurrency(Currency currency);
    }
}