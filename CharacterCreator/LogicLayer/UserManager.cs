using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor _userAccessor;

        public UserManager()
        {
            _userAccessor = new UserAccessor();

        }

        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        public bool AuthenticateUser(string email, string password)
        {
            bool result = false;

            password = HashSHA256(password);
            result = (1 == _userAccessor.SelectUserCountByUsernameAndPasswordHash(email, password));

            return result;

        }

        public User LogInUser(string username, string password)
        {
            User user = null;
            try
            {
                if(AuthenticateUser(username, password))
                {
                    user = RetrieveUserByUsername(username);
                }
                else
                {
                    throw new ArgumentException("Bad Username or Password.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public string HashSHA256(string password)
        {
            
            if (password == "" || password == null)
            {
                throw new ArgumentException("Missing input");
            }

            string hashValue = null;

            byte[] data;

            using (SHA256 sha256provider = SHA256.Create())
            {
                data = sha256provider.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            hashValue = s.ToString().ToLower();

            return hashValue;

        } // no tests

        public User RetrieveUserByUsername(string username)
        {
            User user = null;

            try
            {
                user = _userAccessor.SelectUserByUsername(username);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving user.", ex);
            }

            return user;
        }

        public bool UpdateAccountBio(string username, string oldBio, string newBio)
        {
            bool result = false;

            try
            {
                result = _userAccessor.UpdateAccountBio(username, oldBio, newBio);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateAccountEmail(string username, string oldEmail, string newEmail)
        {
            bool result = false;

            try
            {
                result = _userAccessor.UpdateAccountEmail(username, oldEmail, newEmail);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdatePassword(string username, string email, string oldPassword, string newPassword)
        {
            bool result = false;
            oldPassword = HashSHA256(oldPassword);
            newPassword = HashSHA256(newPassword);

            try
            {
                result = _userAccessor.UpdateAccountPassword(username, email, oldPassword, newPassword);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool CreateNewAccount(string username, string email, string password)
        {
            bool result = false;
            string passwordHash = HashSHA256(password);

            try
            {
                result = _userAccessor.InsertNewAccount(username, email, passwordHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public UserFriend RetrieveFriendStatus(string user, string userFriend)
        {
            UserFriend friend = null;

            try
            {
                friend = _userAccessor.SelectUserFriendStatus(user, userFriend);
            }
            catch (Exception)
            {
                // throw;
            }

            return friend;
        }

        public bool SendFriendRequest(string user, string userFriend)
        {
            bool result = false;

            try
            {
                result = _userAccessor.InsertFriendRequest(user, userFriend);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public List<UserFriend> RetrieveFriendList(string user)
        {
            List<UserFriend> friends = new List<UserFriend>();

            try
            {
                friends = _userAccessor.SelectUserFriends(user);
            }
            catch (Exception)
            {

                throw;
            }

            return friends;
        }

        public List<UserFriend> RetrievePendingFriendRequests(string user)
        {
            List<UserFriend> pending = new List<UserFriend>();

            try
            {
                pending = _userAccessor.SelectPendingFriendRequests(user);
            }
            catch (Exception)
            {

                throw;
            }

            return pending;
        }

        public List<UserFriend> RetrieveFriendRequests(string user)
        {
            List<UserFriend> waiting = new List<UserFriend>();

            try
            {
                waiting = _userAccessor.SelectFriendRequests(user);
            }
            catch (Exception)
            {

                throw;
            }

            return waiting;
        }

        public bool CancelPendingFriendRequest(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.CancelPendingFriendRequest(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool RemoveFriend(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.DeleteUserFriend(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool RejectFriendRequest(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.DenyFriendRequest(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool AcceptFriendRequest(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.AcceptFriendRequest(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            try
            {
                user = _userAccessor.SelectUserByEmail(email);
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public List<User> SelectAllUsers()
        {
            List<User> users = null;

            try
            {
                users = _userAccessor.SelectAllUsers();
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public bool BlockUser(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.BlockUser(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UnblockUser(string user, string otherUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.UnblockUser(user, otherUser);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
