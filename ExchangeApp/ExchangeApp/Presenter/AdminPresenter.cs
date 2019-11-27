using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.View;

namespace ExchangeApp.Presenter.Implementations
{
    public class AdminPresenter
    {
        private readonly AdminView _adminView;
        private readonly CurrencyService _currencyService;
        private readonly OperationService _operationService;

        public AdminPresenter(AdminView adminView, CurrencyService currencyService, OperationService operationService)
        {
            _adminView = adminView;
            _currencyService = currencyService;
            _operationService = operationService;

            _adminView.GetCurrencies += GetCurrencies;
            _adminView.AddCurrency += AddCurrency;
            _operationService.UpdateOperations += UpdateOperations;
            _adminView.FilterOperations += FilterOperations;
        }

        private void FilterOperations(string filter)
        {
            _adminView.UpdateOperations(_operationService.FilterOperations(filter));
        }

        private void UpdateOperations()
        {
            _adminView.UpdateOperations(_operationService.GetOperations());
        }

        public void GetCurrencies()
        {
            _adminView.UpdateCurrencies(_currencyService.GetCurrencies());
        }

        public void AddCurrency(Currency currency)
        {
            _currencyService.addCurrency(currency);
            GetCurrencies();
        }
    }
}