using System;

namespace rental.DataTypes
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Decimal Balance { get; set; }
        public User(){}
        public User(int id, string username, string password, decimal balance)
        {
            Id = id;
            Username = username;
            Password = password;
            Balance = balance;
        }
    }
}
