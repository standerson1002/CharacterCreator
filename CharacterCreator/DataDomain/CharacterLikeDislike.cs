using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class CharacterLikeDislike
    {
        public int CharacterID { get; set; }

        [DisplayName("Like or Dislike")]
        public string LikeDislikeType { get; set; }

        [DisplayName("Thing")]
        public string CharacterInterest { get; set; }

        [DisplayName("Description")][StringLength(100)]
        public string CharacterLikeDislikeDescription { get; set; }

    }
}
