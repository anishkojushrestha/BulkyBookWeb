﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace BulkyBookWeb.Data
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string  Name { get; set; }
        public string?  Address { get; set; }
        public string?  City { get; set; }
        public string?  State { get; set; }
        public string?  PostalCode { get; set; }
    }
}
