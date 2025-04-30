using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class CharacterTrait
    {
        public int CharacterID { get; set; }
        public string TraitID { get; set; }
    }

    public class CharacterTraitVM : CharacterTrait
    {
        public string TraitDescription { get; set; }
        public string TraitConnotation { get; set; }
    }
}
