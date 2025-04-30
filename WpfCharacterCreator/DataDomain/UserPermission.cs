using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataDomain
{
    public class UserPermission
    {
        [Required]
        [DisplayName("User")]
        public string UserID {  get; set; }

        [Required]
        [DisplayName("Creator")]
        public string CreatorID { get; set; }

        [Required]
        public int CharacterID { get; set; }

        [DisplayName("Character")]
        public string CharacterName {  get; set; }

        [Required]
        [DisplayName("Access Type")]
        public string AccessType { get; set; }
    }
}
