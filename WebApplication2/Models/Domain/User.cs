﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models.Domain
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
