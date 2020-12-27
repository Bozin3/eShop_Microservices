using eShop_Core.Entities;

namespace Users.API.Utils
{
    public interface IAuthTokenHandler
    {
        string CreateToken(User user);
        bool CheckValidToken(string token);
    }
}
