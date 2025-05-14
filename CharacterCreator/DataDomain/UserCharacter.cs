using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class UserCharacter
    {
        public int CharacterID { get; set; }
        public string CreatorID { get; set; }

        [Required][DisplayName("Character")]
        public string CharacterName { get; set; }

        [DisplayName("First Name")]
        public string? CharacterFirstName { get; set; }

        [DisplayName("Last Name")]
        public string? CharacterLastName { get; set; }

        [DisplayName("Middle Name")]
        public string? CharacterMiddleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
        public bool Active { get; set; }
    }
    public class AccessCharacter : UserCharacter
    {
        public string AccessType { get; set; }
    }
}
