using System;
using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.Model.Implementations;
using ExchangeApp.View;

namespace ExchangeApp.Presenter.Implementations
{
    public class AdminPresenter: IAdminPresenter
    {
        private readonly IAdminView _adminView;
        private readonly ICurrencyService _currencyService;
        private readonly IOperationService _operationService;

        public AdminPresenter(IAdminView adminView, ICurrencyService currencyService, IOperationService operationService)
        {
            _adminView = adminView;
            _currencyService = currencyService;
            _operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));

            _adminView.GetCurrencies += GetCurrencies;
            _adminView.AddCurrency += AddCurrency;
            _adminView.UpdateCurrency += UpdateCurrency;
            _operationService.UpdateOperations += UpdateOperations;
            _adminView.FilterOperations += FilterOperations;
        }

        private void UpdateCurrency(Currency currency)
        {
            _currencyService.UpdateCurrency(currency);
            GetCurrencies();
        }

        public void FilterOperations(string filter)
        {
            _adminView.UpdateOperations(_operationService.FilterOperations(filter));
        }

        public void UpdateOperations()
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