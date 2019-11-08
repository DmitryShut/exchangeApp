using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface ICashierService
    {
        User GetCashier();
        void SetCashier(User cashier);
    }
}