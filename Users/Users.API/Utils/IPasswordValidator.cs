using eShop_Core.Entities;

namespace Users.API.Utils
{
    public interface IPasswordHandler
    {
        bool CheckValidPassword(string providedPass, User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
