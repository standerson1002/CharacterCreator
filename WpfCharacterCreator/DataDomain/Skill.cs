using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Skill
    {
        public string SkillID { get; set; }
        public string SkillCategory {  get; set; }
        public string SkillDescription { get; set; }
        public string CreatorID { get; set; }
        public bool Custom { get; set; }

    }
}
