using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class User
    {
        [Required(ErrorMessage = "Please enter a valid username.")]
        [DisplayName("Username")][StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a valid username.")]
        [DisplayName("Email")][StringLength(100)][EmailAddress]
        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        [DisplayName("Account Bio")][StringLength(500)]
        public string AccountBio { get; set; }

        public string PasswordHash { get; set; }
        public bool Active { get; set; }

    }
}
