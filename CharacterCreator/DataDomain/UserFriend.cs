using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class UserFriend
    {
        public string UserID { get; set; }

        [DisplayName("Friend's Username")]
        public string UserFriendID { get; set; }
        public string UserFriendStatus { get; set; }

        [DisplayName("Friends Since")]
        public string? UserFriendDate { get; set; }
    }
}
