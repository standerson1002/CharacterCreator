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
        [Required(ErrorMessage = "Please enter a valid username.")]
        [DisplayName("Username")][StringLength(20)]
        public string UserID {  get; set; }

        [Required(ErrorMessage = "Please enter the valid creator.")]
        [DisplayName("Creator")][StringLength(20)]
        public string CreatorID { get; set; }

        [Required]
        public int CharacterID { get; set; }

        [DisplayName("Character")][StringLength(50)]
        public string CharacterName {  get; set; }

        [Required(ErrorMessage = "Please enter a valid access type.")]
        [DisplayName("Access Type")]
        public string AccessType { get; set; }
    }
}
