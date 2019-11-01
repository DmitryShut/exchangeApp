using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Entity
{
    class Money
    {
        private BigInteger Amount { get; set; }
        private Currency Currency { get; set; }
    }
}
