using ExchangeApp.Entity;

namespace ExchangeApp.Model.Implementations
{
    public class CashierService: ICashierService
    {
        private User _cashier;

        public User GetCashier()
        {
            return _cashier;
        }

        public void SetCashier(User cashier)
        {
            _cashier = cashier;
        }
    }
}