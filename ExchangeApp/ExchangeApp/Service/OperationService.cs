using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;
using ExchangeApp.Presenter.Implementations;
using ExchangeApp.Repository;

namespace ExchangeApp.Model.Implementations
{
    public class OperationService
    {
        public IRepository<Operation, DateTime> operationRepository;

        public OperationService(IRepository<Operation, DateTime> operationRepository)
        {
            this.operationRepository = operationRepository;
        }

        public BigInteger PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount,
            User user, OperationType operationType, User cashier)
        {
            List<Operation> operations = operationRepository.FindByCondition(x =>
                x.Date.Day.Equals(DateTime.Now.Day) &&
                x.User.ToString().Equals(user.ToString()) &&
                x.TargetCurrency.CurrencyName.Equals(targetCurrency.CurrencyName) &&
                x.Type.Equals(operationType)
            );
            BigInteger userTotalAmount = !operations.Count.Equals(0)
                ? operations.Select(x => x.TargetAmount).Aggregate((x, y) => x + y)
                : new BigInteger(0);
            BigInteger targetAmount;
            if (targetCurrency.Equals(userCurrency))
            {
                targetAmount = userAmount;
            }
            else
            {
                if (operationType.Equals(OperationType.Purchase))
                {
                    targetAmount = userAmount * targetCurrency.PurchaseRate / userCurrency.SellingRate;
                    if ((userTotalAmount + targetAmount) > targetCurrency.PurchaseLimit)
                    {
                        throw new ArithmeticException();
                    }
                }
                else
                {
                    targetAmount = userAmount * targetCurrency.SellingRate / userCurrency.PurchaseRate;
                    if ((userTotalAmount + targetAmount) > targetCurrency.SellingRate)
                    {
                        throw new ArithmeticException();
                    }
                }
            }
            operationRepository.Create(new Operation(DateTime.Now, user,
                operationType, userCurrency,
                userAmount, targetCurrency, targetAmount, cashier), DateTime.Now);
            UpdateOperations?.Invoke();
            return targetAmount;
        }

        public List<Operation> GetOperations()
        {
            return operationRepository.FindAll();
        }

        public List<Operation> FilterOperations(string filter)
        {
            try
            {
                string[] filterParams =
                    filter.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                List<Operation> operations;
                switch (filterParams[0])
                {
                    case "Date":
                        operations =
                            operationRepository.FindByCondition(x =>
                                x.Date >= DateTime.Parse(filterParams[1]) && x.Date <= DateTime.Parse(filterParams[2]));
                        break;
                    case "User":
                        operations = operationRepository.FindByCondition(x =>
                            x.User.ToString().Equals(filterParams[1]));
                        break;
                    case "Cashier":
                        operations = operationRepository.FindByCondition(x =>
                            x.Cashier.ToString().Equals(filterParams[1]));
                        break;
                    case "Type":
                        operations = operationRepository.FindByCondition(x =>
                            x.Type.ToString().Equals(filterParams[1]));
                        break;
                    case "UserCurrency":
                        operations = operationRepository.FindByCondition(x =>
                            x.UserCurrency.CurrencyName.Equals(filterParams[1]));
                        break;
                    case "UserAmount":
                        operations = operationRepository.FindByCondition(x =>
                            x.UserAmount.Equals(BigInteger.Parse(filterParams[1])));
                        break;
                    case "TargetCurrency":
                        operations = operationRepository.FindByCondition(x =>
                            x.TargetCurrency.CurrencyName.Equals(filterParams[1]));
                        break;
                    case "TargetAmount":
                        operations = operationRepository.FindByCondition(x =>
                            x.TargetAmount.Equals(BigInteger.Parse(filterParams[1])));
                        break;
                    default:
                        operations = operationRepository.FindAll();
                        break;
                }

                return operations;
            }
            catch (Exception e)
            {
                return operationRepository.FindAll();
            }
        }

        public List<Operation> GetOperations(string filter)
        {
            return operationRepository.FindAll();
        }

        public event ServiceDelegates.UpdateOperations UpdateOperations;
    }
}