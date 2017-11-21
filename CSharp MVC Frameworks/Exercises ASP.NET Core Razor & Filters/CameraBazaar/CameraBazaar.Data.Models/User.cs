using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CameraBazaar.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public ICollection<Camera> Cameras { get; set; } = new List<Camera>();

        public DateTime? LastLogin { get; set; }

        public bool IsBanned { get; set; }
    }
}