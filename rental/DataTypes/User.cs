using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.DataTypes
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Decimal Balance { get; set; }
        public User(){}
        public User(string login, string password, decimal balance)
        {
            Login = login;
            Password = password;
            Balance = balance;
        }
    }
}
