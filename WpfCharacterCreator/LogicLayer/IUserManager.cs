using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserManager
    {

        User SelectUserByEmail(string email);
        List<User> SelectAllUsers();

        string HashSHA256(string password);
        bool AuthenticateUser(string username, string password);
        User RetrieveUserByUsername(string username);
        public User LogInUser(string username, string password);
        bool UpdateAccountBio(string username, string oldBio, string newBio);
        bool UpdateAccountEmail(string username, string oldEmail, string newEmail);
        bool UpdatePassword(string username, string email, string oldPassword, string newPassword);
        bool CreateNewAccount(string username, string email, string password);
        UserFriend RetrieveFriendStatus(string user, string userFriend);
        bool SendFriendRequest(string user, string userFriend);
        List<UserFriend> RetrieveFriendList(string user);
        List<UserFriend> RetrievePendingFriendRequests(string user);
        List<UserFriend> RetrieveFriendRequests(string user);
        bool CancelPendingFriendRequest(string user, string otherUser);
        bool RemoveFriend(string user, string otherUser);
        bool RejectFriendRequest(string user, string otherUser);
        bool AcceptFriendRequest(string user, string otherUser);
    }
}
