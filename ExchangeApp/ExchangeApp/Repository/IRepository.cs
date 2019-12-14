using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Repository
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        List<T> FindByCondition(Func<T, bool> expression);
        void Create(T entity);
        void Update(T entity);
    }
}