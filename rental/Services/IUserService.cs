using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserByLogin(String login);

        Task<User> AddUser(User user);

        Task<bool> DeleteUser(String login);

        Task<bool> verify(string login, string password);


    }
}
