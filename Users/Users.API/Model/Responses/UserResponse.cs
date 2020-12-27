using eShop_Core.Entities;
using System.Collections.Generic;

namespace Users.API.Model.Responses
{
    public class UserResponse
    {
        public UserResponse()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Age { get; set; }
        public string PhotoUrl { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
