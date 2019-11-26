using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ExchangeApp.Entity;

namespace ExchangeApp.Repository
{
    public class Repository<T, U> : IRepository<T, U>
    {
        private Dictionary<U, T> collection = new Dictionary<U, T>();

        public List<T> FindAll()
        {
            return new List<T>(collection.Values);
        }

        public List<T> FindByCondition(Func<T, bool> expression)
        {
            return new List<T>(collection.Values.Where(expression));
        }

        public void Create(T entity, U id)
        {
            collection[id] = entity;
        }

        public void Update(T entity, U id)
        {
            collection[id] = entity;
        }

        public void Delete(U id)
        {
            collection.Remove(id);
        }
    }
}