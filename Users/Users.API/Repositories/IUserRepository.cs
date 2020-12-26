using eShop_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Model.Requests;

namespace Users.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(String email);
        Task<bool> UpdateUser(User user);
        Task<int> AddUser(User user);
        Task DeleteUser(User user);
        bool UserExists(int id);
    }
}
