using Microsoft.AspNetCore.Identity;
using System;

namespace FalzoGamer.Admin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
