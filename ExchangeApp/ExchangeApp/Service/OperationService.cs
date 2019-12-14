using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using ExchangeApp.Entity;
using ExchangeApp.Presenter.Implementations;
using ExchangeApp.Repository;

namespace ExchangeApp.Model.Implementations
{
    public class OperationService : IOperationService
    {
        public IRepository<Operation, DateTime> operationRepository;

        public OperationService(IRepository<Operation, DateTime> operationRepository)
        {
            this.operationRepository = operationRepository;
        }

        private List<Operation> GetOperationsForLimitCheck(User user, Currency targetCurrency,
            OperationType operationType)
        {
            return operationRepository.FindByCondition(x =>
                x.Date.Day.Equals(DateTime.Now.Day) &&
                x.User.ToString().Equals(user.ToString()) &&
                x.TargetCurrency.CurrencyName.Equals(targetCurrency.CurrencyName) &&
                x.Type.Equals(operationType)
            );
        }

        private BigInteger GetUserAmountByCurrency(List<Operation> operations)
        {
            return !operations.Count.Equals(0)
                ? operations.Select(x => x.TargetAmount).Aggregate((x, y) => x + y)
                : new BigInteger(0);
        }

        public BigInteger PerformOperation(Currency userCurrency, Currency targetCurrency, BigInteger userAmount,
            User user, OperationType operationType, User cashier)
        {
            List<Operation> operations = GetOperationsForLimitCheck(user, targetCurrency, operationType);
            BigInteger userTotalAmount = GetUserAmountByCurrency(operations);
            BigInteger targetAmount = GetTargetAmount(targetCurrency, userCurrency, userAmount, operationType);
            if (LimitCheck(operationType, targetAmount, userTotalAmount, targetCurrency))
            {
                throw new ArithmeticException();
            }

            operationRepository.Create(new Operation(DateTime.Now, user,
                operationType, userCurrency,
                userAmount, targetCurrency, targetAmount, cashier), DateTime.Now);
            UpdateOperations?.Invoke();
            return targetAmount;
        }

        private BigInteger GetTargetAmount(Currency targetCurrency, Currency userCurrency, BigInteger userAmount,
            OperationType operationType)
        {
            if (targetCurrency.Equals(userCurrency))
            {
                return userAmount;
            }

            if (operationType.Equals(OperationType.Purchase))
            {
                return userAmount * targetCurrency.PurchaseRate / userCurrency.SellingRate;
            }

            return userAmount * targetCurrency.SellingRate / userCurrency.PurchaseRate;
        }

        private bool LimitCheck(OperationType operationType, BigInteger targetAmount, BigInteger userTotalAmount,
            Currency targetCurrency)
        {
            if (operationType.Equals(OperationType.Purchase))
            {
                return (userTotalAmount + targetAmount) > targetCurrency.PurchaseLimit;
            }

            return (userTotalAmount + targetAmount) > targetCurrency.SellingRate;
        }

        public List<Operation> GetOperations()
        {
            return operationRepository.FindAll();
        }

        public List<Operation> FilterOperations(string f)
        {
            try
            {
                string[] filters = Split(";", f);
                return operationRepository.FindByCondition(operation =>
                    {
                        var filterParams = filters[0].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        var result = GetFilterCondition(filterParams[1], typeof(Operation), filterParams[0], operation);
                        for (int i = 1; i < filters.Length; i++)
                        {
                            filterParams = Split("=", filters[i]);
                            result = result && GetFilterCondition(filterParams[1], typeof(Operation), filterParams[0],
                                         operation);
                        }

                        return result;
                    }
                );
            }
            catch (Exception e)
            {
                return operationRepository.FindAll();
            }
        }

        private string[] Split(string separator, string stringToSplit)
        {
            return stringToSplit.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private bool GetFilterCondition(string value, Type type, string filterField, Object obj)
        {
            return value
                .Equals(type.GetProperty(filterField).GetValue(obj)
                    .ToString());
        }

        public List<Operation> GetOperations(string filter)
        {
            return operationRepository.FindAll();
        }

        public event ServiceDelegates.UpdateOperations UpdateOperations;
    }
}