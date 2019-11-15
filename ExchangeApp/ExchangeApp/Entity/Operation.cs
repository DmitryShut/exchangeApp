using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Entity
{
    public class Operation
    {
        public DateTime Date { get; set; }
        public User User { get; set; }
        public OperationType Type { get; set; }
        public Currency userCurrency { get; set; }
        public BigInteger userAmount { get; set; }
        public Currency targetCurrency { get; set; }
        public BigInteger targetAmount { get; set; }

        public Operation(DateTime date, User user, OperationType type, Currency userCurrency, BigInteger userAmount, Currency targetCurrency, BigInteger targetAmount)
        {
            Date = date;
            User = user;
            Type = type;
            this.userCurrency = userCurrency;
            this.userAmount = userAmount;
            this.targetCurrency = targetCurrency;
            this.targetAmount = targetAmount;
        }
    }
}