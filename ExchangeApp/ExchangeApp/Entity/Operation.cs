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
        public long Date { get; set; }
        public User User { get; set; }
        public User Cashier { get; set; }
        public OperationType Type { get; set; }
        public Currency userCurrency { get; set; }
        public BigInteger userAmount { get; set; }
        public Currency targetCurrency { get; set; }
        public BigInteger targetAmount { get; set; }

        public Operation(long date, User user, OperationType type, Currency userCurrency, BigInteger userAmount, Currency targetCurrency, BigInteger targetAmount, User cashier)
        {
            Date = date;
            User = user;
            Cashier = cashier;
            Type = type;
            this.userCurrency = userCurrency;
            this.userAmount = userAmount;
            this.targetCurrency = targetCurrency;
            this.targetAmount = targetAmount;
        }
    }
}