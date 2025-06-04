using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class CharacterSkill
    {
        [DisplayName("Character")]
        public int CharacterID { get; set; }

        [DisplayName("Skill")]
        public string SkillID { get; set; }

        [DisplayName("Description")][StringLength(100)]
        public string CharacterSkillDescription { get; set; }
    }
}
