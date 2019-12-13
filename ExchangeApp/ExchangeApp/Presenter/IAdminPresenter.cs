using ExchangeApp.Entity;

namespace ExchangeApp.Presenter.Implementations
{
    public interface IAdminPresenter
    {
        void FilterOperations(string filter);

        void UpdateOperations();

        void GetCurrencies();

        void AddCurrency(Currency currency);
    }
}