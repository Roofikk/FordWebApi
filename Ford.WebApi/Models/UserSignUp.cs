﻿namespace Ford.WebApi.Models
{
    public class UserSignUp
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set;} = null!;
        public string Email { get; set; } = null!;
    }
}
