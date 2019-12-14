using System;

namespace ExchangeApp.Attribute
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
    public class Id : System.Attribute
    {
        public Id()
        {
        }
    }
}