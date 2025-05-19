using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using DataDomain;


namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public bool AcceptFriendRequest(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_accept_friend_request", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = otherUser;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 2);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool BlockUser(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_block_user", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Blocker", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@Blocked", SqlDbType.NVarChar, 20);
            cmd.Parameters["@Blocker"].Value = user;
            cmd.Parameters["@Blocked"].Value = otherUser;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                result = SelectUserFriendStatus(user, otherUser).UserFriendStatus == "blocked"
                      && SelectUserFriendStatus(otherUser, user).UserFriendStatus == "blocker";
            }
            catch (Exception)
            {
                // throw;
            }

            return result;
        }

        public bool UnblockUser(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_unblock_user", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Blocker", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@Blocked", SqlDbType.NVarChar, 20);
            cmd.Parameters["@Blocker"].Value = user;
            cmd.Parameters["@Blocked"].Value = otherUser;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
        


        public bool CancelPendingFriendRequest(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_cancel_pending_friend_requests", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = otherUser;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 2);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool DeleteUserFriend(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_friend", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = otherUser;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 2);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool DenyFriendRequest(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_deny_friend_request", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = otherUser;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 2);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool InsertFriendRequest(string user, string otherUser)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_send_friend_request", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = otherUser;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                result = SelectUserFriendStatus(user, otherUser).UserFriendStatus == "pending"
                      && SelectUserFriendStatus(otherUser, user).UserFriendStatus == "waiting";
            }
            catch (Exception)
            {
                // throw;
            }

            return result;
        }

        public bool InsertNewAccount(string username, string email, string passwordHash)
        {
            bool result = false;
            
            if (SelectUserByUsername(username) == null)
            {

                var conn = DatabaseConnection.GetConnection();
                var cmd = new SqlCommand("sp_create_new_account", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

                cmd.Parameters["@UserID"].Value = username;
                cmd.Parameters["@Email"].Value = email;
                cmd.Parameters["@PasswordHash"].Value = passwordHash;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    result = (1 == SelectUserCountByUsernameAndPasswordHash(username, passwordHash));
                }
                catch (Exception)
                {
                    throw new ArgumentException("Email Already Taken.");
                }
            }
            else
            {
                throw new ArgumentException("Username Already Taken.");
            }
            
            return result;
        }

        public List<User> SelectAllUsers()
        {
            List<User> users = new List<User>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_all_users", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Username = reader.GetString(0),
                            Email = reader.GetString(1),
                            ProfilePicture = reader.GetString(2),
                            AccountBio = reader.GetString(3),
                            Active = reader.GetBoolean(4)
                        };
                        users.Add(user);
                    }
                }
                else
                {
                    // throw new ArgumentException("User Not Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public List<UserFriend> SelectFriendRequests(string user)
        {
            List<UserFriend> waiting = new List<UserFriend>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_friend_requests", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    waiting.Add(new UserFriend()
                    {
                        UserID = user,
                        UserFriendID = reader.GetString(0),
                        UserFriendStatus = "waiting",
                        UserFriendDate = null
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return waiting;
        }

        public List<UserFriend> SelectPendingFriendRequests(string user)
        {
            List<UserFriend> pending = new List<UserFriend>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_pending_requests", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    pending.Add(new UserFriend()
                    {
                        UserID = user,
                        UserFriendID = reader.GetString(0),
                        UserFriendStatus = "pending",
                        UserFriendDate = null
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return pending;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_user_by_email", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Email"].Value = email;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    user = new User()
                    {
                        Username = reader.GetString(0),
                        Email = reader.GetString(1),
                        ProfilePicture = reader.GetString(2),
                        AccountBio = reader.GetString(3),
                        Active = reader.GetBoolean(4)
                    };
                }
                else
                {
                    // throw new ArgumentException("User Not Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public User SelectUserByUsername(string username)
        {
            User user = null;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_account_profile", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = username;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    
                    user = new User()
                    {
                        Username = reader.GetString(0),
                        Email = reader.GetString(1),
                        ProfilePicture = reader.GetString(2),
                        AccountBio = reader.GetString(3),
                        Active = reader.GetBoolean(4)
                    };
                }
                else
                {
                    // throw new ArgumentException("User Not Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public int SelectUserCountByUsernameAndPasswordHash(string username, string passwordHash)
        {
            int count = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_authenticate_user", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters["@UserID"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                count = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Authentication Failed", ex);
            }
            finally
            {
                conn.Close();
            }
            
            return count;
        }

        public List<UserFriend> SelectUserFriends(string user)
        {
            List<UserFriend> friends = new List<UserFriend>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_friends", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    friends.Add(new UserFriend()
                    {
                        UserID = user,
                        UserFriendID = reader.GetString(0),
                        UserFriendStatus = "friend",
                        // converting date code source:
                        // https://stackoverflow.com/questions/4097127/getting-date-or-time-only-from-a-datetime-object
                        UserFriendDate = reader.GetDateTime(1).ToShortDateString()
                    });
                }
                
                }

            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return friends;
        }

        public UserFriend SelectUserFriendStatus(string user, string userFriend)
        {
            UserFriend friend = null;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_friend_status", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@UserFriendID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@UserFriendID"].Value = userFriend;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    friend = new UserFriend()
                    {
                        UserFriendStatus = reader.GetString(0),
                        UserFriendDate = reader.GetDateTime(1).ToShortDateString()
                    };
                }
                else
                {
                    throw new ArgumentException("No Relationship.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return friend;
        }

        public bool UpdateAccountBio(string username, string oldBio, string newBio)
        {
            bool result = false;
            User user = null;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_account_bio", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@OldAccountBio", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@NewAccountBio", SqlDbType.NVarChar, 500);

            cmd.Parameters["@UserID"].Value = username;
            cmd.Parameters["@OldAccountBio"].Value = oldBio;
            cmd.Parameters["@NewAccountBio"].Value = newBio;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 1);
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

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_account_email", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@OldEmail", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewEmail", SqlDbType.NVarChar, 100);

            cmd.Parameters["@UserID"].Value = username;
            cmd.Parameters["@OldEmail"].Value = oldEmail;
            cmd.Parameters["@NewEmail"].Value = newEmail;

            try
            {
                conn.Open();
                if(cmd.ExecuteNonQuery() == 1)
                {
                    result = true;
                }
                else
                {
                    throw new ArgumentException("Email Already Taken.");
                }
                
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateAccountPassword(string username, string email, string oldPassword, string newPassword)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_account_password", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@UserID"].Value = username;
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@OldPasswordHash"].Value = oldPassword;
            cmd.Parameters["@NewPasswordHash"].Value = newPassword;

            try
            {
                conn.Open();
                result = (cmd.ExecuteNonQuery() == 1);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
