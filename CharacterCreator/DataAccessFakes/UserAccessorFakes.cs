using DataAccessInterfaces;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class UserAccessorFakes : IUserAccessor
    {

        private List<User> _users;
        private List<UserFriend> _friends;

        public UserAccessorFakes()
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Username = "test1",
                Email = "test1@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });
            _users.Add(new User()
            {
                Username = "test2",
                Email = "test2@test.com",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = false
            });
            _users.Add(new User()
            {
                Username = "test4",
                Email = "test4@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });
            _users.Add(new User()
            {
                Username = "test5",
                Email = "test5@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });
            _users.Add(new User()
            {
                Username = "test6",
                Email = "test6@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });

            _friends = new List<UserFriend>();
            _friends.Add(new UserFriend()
            {
                UserID = "test1",
                UserFriendID = "test4",
                UserFriendStatus = "pending",
                UserFriendDate = null
            });
            _friends.Add(new UserFriend()
            {
                UserID = "test1",
                UserFriendID = "test5",
                UserFriendStatus = "waiting",
                UserFriendDate = null
            });
            _friends.Add(new UserFriend()
            {
                UserID = "test1",
                UserFriendID = "test6",
                UserFriendStatus = "friend",
                UserFriendDate = DateTime.Now.AddDays(0).ToString()
            });

        }

        public bool AcceptFriendRequest(string user, string otherUser)
        {
            return UserFriendHelper(user, otherUser, "waiting", "friend");
        }

        public bool CancelPendingFriendRequest(string user, string otherUser)
        {
            return UserFriendHelper(user, otherUser, "pending", "");
        }

        public bool DeleteUserFriend(string user, string otherUser)
        {
            return UserFriendHelper(user, otherUser, "friend", "");
        }

        public bool DenyFriendRequest(string user, string otherUser)
        {
            return UserFriendHelper(user, otherUser, "waiting", "");
        }


        public bool InsertFriendRequest(string user, string otherUser)
        {
            bool result = false;

            _friends.Add(new UserFriend()
            {
                UserID = user,
                UserFriendID = otherUser,
                UserFriendStatus = "pending",
                UserFriendDate = null

            });
            _friends.Add(new UserFriend()
            {
                UserID = otherUser,
                UserFriendID = user,
                UserFriendStatus = "waiting",
                UserFriendDate = null

            });

            if (SelectUserFriendStatus(user, otherUser).UserFriendStatus == "pending" 
                && SelectUserFriendStatus(otherUser, user).UserFriendStatus == "waiting")
            {
                result = true;
            }

            return result;
        }

        public bool InsertNewAccount(string username, string email, string passwordHash)
        {
            bool result = true;

            foreach (User user in _users)
            {
                if (user.Username == username || user.Email == email)
                {
                    result = false;
                }
            }

            if (result)
            {
                _users.Add(new User()
                {
                    Username = username,
                    Email = email,
                    AccountBio = "",
                    PasswordHash = passwordHash,
                    Active = true
                });

                result = (1 == SelectUserCountByUsernameAndPasswordHash(username, passwordHash));
            }

            return result;

        }

        public List<User> SelectAllUsers()
        {
            return _users;
        }

        public List<UserFriend> SelectFriendRequests(string user)
        {
            List<UserFriend> waiting = new List<UserFriend>();

            foreach (UserFriend friend in _friends)
            {
                if (friend.UserID == user && friend.UserFriendStatus == "waiting")
                {
                    waiting.Add(friend);
                }
            }

            return waiting;
        }

        public List<UserFriend> SelectPendingFriendRequests(string user)
        {
            List<UserFriend> pending = new List<UserFriend>();

            foreach (UserFriend friend in _friends)
            {
                if (friend.UserID == user && friend.UserFriendStatus == "pending")
                {
                    pending.Add(friend);
                }
            }

            return pending;
        }

        public User SelectUserByEmail(string email)
        {
            User result = null;

            foreach(User user in _users)
            {
                if(user.Email == email)
                {
                    result = user;
                    break;
                }
            }

            return result;
        }

        public User SelectUserByUsername(string username)
        {
            foreach (User user in _users)
            {
                if(user.Username == username)
                {
                    return user;
                }
            }
            throw new ArgumentException("User not found");

        }

        public int SelectUserCountByUsernameAndPasswordHash(string username, string passwordHash)
        {
            int count = 0;
            foreach (var user in _users)
            {
                if(user.Username == username && user.PasswordHash == passwordHash && user.Active == true)
                {
                    count++;
                }
            }
            return count;
        }

        public List<UserFriend> SelectUserFriends(string user)
        {
            List<UserFriend> friends = new List<UserFriend>();

            foreach(UserFriend friend in _friends)
            {
                if(friend.UserID == user && friend.UserFriendStatus == "friend")
                {
                    friends.Add(friend);
                }
            }
                
            return friends;
        }

        public UserFriend SelectUserFriendStatus(string user, string userFriend)
        {
            foreach (UserFriend friend in _friends)
            {
                if(friend.UserID == user && friend.UserFriendID == userFriend)
                {
                    return friend;
                }
            }
            throw new ArgumentException("No Relationship");
        }

        public bool UpdateAccountBio(string username, string oldBio, string newBio)
        {
            bool result = false;
            User user = SelectUserByUsername(username);
            if (user.AccountBio == oldBio)
            {
                user.AccountBio = newBio;
                result = true;
            }
            return result;
        }

        public bool UpdateAccountEmail(string username, string oldEmail, string newEmail)
        {
            bool result = true;

            foreach (User user in _users)
            {
                if (user.Email == newEmail)
                {
                    result = false;
                }
            }

            if (result)
            {
                result = false;
                User user = SelectUserByUsername(username);
                if (user.Email == oldEmail)
                {
                    user.Email = newEmail;
                    result = true;
                }
            }

            return result;

        }

        public bool UpdateAccountPassword(string username, string email, string oldPassword, string newPassword)
        {
            bool result = false;
            User user = SelectUserByUsername(username);
            if (user.Email == email && user.PasswordHash == oldPassword)
            {
                user.PasswordHash = newPassword;
                result = true;
            }
            return result;
        }

        // Helpers
       public bool UserFriendHelper(string user, string otherUser, string role, string change)
        {
            bool result = false;

            foreach (UserFriend friend in _friends)
            {
                if (friend.UserID == user && friend.UserFriendID == otherUser && friend.UserFriendStatus == role)
                {
                    friend.UserFriendStatus = change;
                    result = true;
                }
            }

            return result;
        }
    }

   
}
