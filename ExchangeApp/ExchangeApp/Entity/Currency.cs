using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ExchangeApp.Attribute;

namespace ExchangeApp.Entity
{
    public class Currency
    {
        [Id()]
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

        public override string ToString()
        {
            return CurrencyName;
        }
    }
}
