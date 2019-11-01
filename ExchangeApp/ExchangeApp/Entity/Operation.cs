using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Entity
{
    class Operation
    {
        private DateTime Date { get; set; }
        private User User { get; set; }
        private OperationType Type { get; set; }
    }
}
