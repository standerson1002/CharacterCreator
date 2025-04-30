using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Trait
    {
        public string TraitID {  get; set; }
        public string TraitConnotation { get; set; }
        public string TraitDescription { get; set; }
        public string CreatorID { get; set; }
        public bool Custom { get; set; }

    }
}
