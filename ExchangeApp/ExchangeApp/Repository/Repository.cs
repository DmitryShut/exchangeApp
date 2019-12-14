using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private List<T> collection = new List<T>();

        public List<T> FindAll()
        {
            return collection;
        }

        public List<T> FindByCondition(Func<T, bool> expression)
        {
            return new List<T>(collection.Where(expression));
        }

        public void Create(T entity)
        {
            collection.Add(entity);
        }
    }
}