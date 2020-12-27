using eShop_Core.Entities;
using Users.API.Model.Requests;
using Users.API.Model.Responses;

namespace Users.API.Utils
{
    public static class Mapper
    {
        public static UserResponse ToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Fname = user.Fname,
                Lname = user.Lname,
                Age = user.Age,
                PhotoUrl = user.PhotoUrl,
                Addresses = user.Addresses,
                Orders = user.Orders
            };
        }

        public static User ToUser(this UpdateUserRequest updateUserRequest)
        {
            return new User
            {
                Id = updateUserRequest.Id,
                Email = updateUserRequest.Email,
                Fname = updateUserRequest.Fname,
                Lname = updateUserRequest.Lname,
                PhotoUrl = updateUserRequest.PhotoUrl
            };
        }

        public static User ToUser(this RegisterRequest updateUserRequest)
        {
            return new User
            {

                Email = updateUserRequest.Email,
                Fname = updateUserRequest.Fname,
                Lname = updateUserRequest.Lname,
                Age = updateUserRequest.Age
            };
        }
    }
}
