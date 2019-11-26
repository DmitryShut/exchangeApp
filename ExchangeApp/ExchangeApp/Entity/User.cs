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

        public User()
        {
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}