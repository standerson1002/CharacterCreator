using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string AccountBio { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }

    }
}
