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

        [Required(ErrorMessage = "Please enter a valid character name.")]
        [DisplayName("Character")][StringLength(50)]
        public string CharacterName { get; set; }

        [DisplayName("First Name")][StringLength(50)]
        public string? CharacterFirstName { get; set; }

        [DisplayName("Last Name")][StringLength(50)]
        public string? CharacterLastName { get; set; }

        [DisplayName("Middle Name")][StringLength(50)]
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
