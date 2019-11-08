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
        public string CurrencyName { get; set; }
        private BigInteger PurchaseRate { get; set; }
        private BigInteger SellingRate { get; set; }
        private BigInteger PurchaseLimit { get; set; }
        private BigInteger SellingLimit { get; set; }

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
