using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.DataTypes
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Decimal Balance { get; set; }
        public User(){}
        public User(string username, string password, decimal balance)
        {
            Username = username;
            Password = password;
            Balance = balance;
        }
    }
}
