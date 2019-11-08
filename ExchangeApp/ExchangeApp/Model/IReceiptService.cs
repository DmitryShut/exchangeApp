using System.IO;
using ExchangeApp.Entity;

namespace ExchangeApp.Model
{
    public interface IReceiptService
    {
        Stream GetReceipt(Operation operation);
    }
}