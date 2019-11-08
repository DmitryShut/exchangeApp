using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Entity
{
    public class User
    {
        public User(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private string Name { get; set; }

        private string Surname { get; set; }
    }
}
