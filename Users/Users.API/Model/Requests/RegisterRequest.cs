﻿using System.ComponentModel.DataAnnotations;

namespace Users.API.Model.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        public int? Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
