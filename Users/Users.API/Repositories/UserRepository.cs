using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Core;
using eShop_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Users.API.Model.Requests;

namespace Users.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly eShopContext context;

        public UserRepository(eShopContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public Task<List<User>> GetUsers()
        {
            return context.Users.ToListAsync();
        }

        public async Task<int> AddUser(User user)
        {
            context.Users.Add(user);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var entry = context.Entry(user);
            entry.Property(u => u.Email).IsModified = true;
            entry.Property(u => u.Fname).IsModified = true;
            entry.Property(u => u.Lname).IsModified = true;
            entry.Property(u => u.PhotoUrl).IsModified = true;
            return await context.SaveChangesAsync() > 0;
        }

        public bool UserExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
