using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Entity
{
    class Rate
    {
        private Currency Currency { get; set; }
        private DateTime Date { get; set; }
        private BigInteger PurchaseRate { get; set; }
        private BigInteger SellingRate { get; set; }
    }
}
