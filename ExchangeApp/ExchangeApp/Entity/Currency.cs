using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ExchangeApp.Entity
{
    public class Currency
    {
        public BigInteger Id { get; set; }
        public string CurrencyName { get; set; }
        public BigInteger PurchaseRate { get; set; }
        public BigInteger SellingRate { get; set; }
        public BigInteger PurchaseLimit { get; set; }
        public BigInteger SellingLimit { get; set; }

        public Currency(string currencyName, BigInteger purchaseRate, BigInteger sellingRate, BigInteger purchaseLimit, BigInteger sellingLimit)
        {
            CurrencyName = currencyName;
            PurchaseRate = purchaseRate;
            SellingRate = sellingRate;
            PurchaseLimit = purchaseLimit;
            SellingLimit = sellingLimit;
        }
    }
}
