using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IUserAccessor
    {
        User SelectUserByEmail(string email);
        List<User> SelectAllUsers();
        int SelectUserCountByUsernameAndPasswordHash(string username, string passwordHash);
        User SelectUserByUsername(string username);
        UserFriend SelectUserFriendStatus(string user, string userFriend);
        List<UserFriend> SelectUserFriends(string user);
        List<UserFriend> SelectPendingFriendRequests(string user);
        List<UserFriend> SelectFriendRequests(string user);
        bool CancelPendingFriendRequest(string user, string otherUser);
        bool UpdateAccountBio(string username, string oldBio, string newBio);
        bool UpdateAccountEmail(string username, string oldEmail, string newEmail);
        bool UpdateAccountPassword(string  username, string email, string oldPassword, string newPassword);
        bool InsertNewAccount(string username, string email, string passwordHash);
        bool InsertFriendRequest(string user, string otherUser);
        bool DeleteUserFriend(string user, string otherUser);
        bool DenyFriendRequest(string user, string otherUser);
        bool AcceptFriendRequest(string user, string otherUser);

        bool BlockUser(string user, string otherUser);
        bool UnblockUser(string user, string otherUser);


    }
}
