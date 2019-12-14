using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using Castle.Core.Internal;
using ExchangeApp.Attribute;
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

        public void Update(T entity)
        {
            var propertyInfo = getPropertyInfo(typeof(T));
            var idValue = (string) propertyInfo.GetValue(entity);
            var ent = collection.Find(item => ((string) propertyInfo.GetValue(item)).Equals(idValue));
            var indexOf = collection.IndexOf(ent);
            collection[indexOf] = entity;
        }

        private PropertyInfo getPropertyInfo(Type type)
        {
            var propertyInfos = type.GetProperties();
            PropertyInfo propertyInfo = null;
            foreach (var property in propertyInfos)
            {
                if (property.GetAttribute<Id>() != null)
                {
                    propertyInfo = property;
                }
            }

            return propertyInfo;
        }
    }
}