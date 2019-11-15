using ExchangeApp.Entity;
using ExchangeApp.Model;
using ExchangeApp.View;
using Delegates = ExchangeApp.Model.Delegates;

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
            _operationService = operationService;

            _adminView.GetCurrencies += GetCurrencies;
            _adminView.AddCurrency += AddCurrency;
            _operationService.UpdateOperations += UpdateOperations;
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