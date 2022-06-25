using Microsoft.EntityFrameworkCore;
using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public class UserService : IUserService
    {
        private readonly RentalDbContextFactory _contextFactory;

        public UserService(RentalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> AddUser(User user)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                var newUser = await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return newUser.Entity;
            }
        }

        public async Task<bool> DeleteUser(string login)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                User user = await context.Users.FirstOrDefaultAsync((u) => u.Login.Equals(login));
                if (user == null)
                {
                    throw new Exception("User with login:" + login + " doesn't exist");
                }
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                List<User> allUsers = await context.Users.ToListAsync();
                return allUsers; 
            } 
        }

        public async Task<User> GetUserByLogin(string login)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                User user = await context.Users.FirstOrDefaultAsync((u) => u.Login.Equals(login));
                if (user == null)
                {
                    throw new Exception("User with login:" + login + " doesn't exist");
                }
                return user;
            }
        }

        public async Task<bool> verify(string login, string password)
        {
            using (RentalDbContext context = _contextFactory.CreateDbContext())
            {
                User user = await context.Users.FirstOrDefaultAsync((u) => u.Login.Equals(login));
                    if (user != null)
                        if (user.Password.Equals(password))
                            return true;
                    return false;
                }
        }
    }
}
