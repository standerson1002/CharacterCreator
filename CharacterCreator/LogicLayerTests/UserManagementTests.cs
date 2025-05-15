using DataAccessFakes;
using DataDomain;
using LogicLayer;

namespace LogicLayerTests
{
    [TestClass]
    public class UserManagementTests
    {
        private IUserManager? _userManager;

        [TestInitialize]
        public void TestSetup()
        {
            _userManager = new UserManager(new UserAccessorFakes());
        }


        [TestMethod]
        public void TestAuthenticateUserReturnsTrueForUsernameAndPassword()
        {
            // arrange
            const string username = "test1";
            const string password = "password";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.AuthenticateUser(username, password);

            //assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestAuthenticateUserReturnsFalseForGoodUsername()
        {
            // arrange
            const string username = "test";
            const string password = "password";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.AuthenticateUser(username, password);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAuthenticateUserReturnsFalseForGoodPassword()
        {
            // arrange
            const string username = "test1";
            const string password = "badpassword";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.AuthenticateUser(username, password);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAuthenticateUserReturnsFalseForActiveUser()
        {
            // arrange
            const string username = "test2";
            const string password = "password";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.AuthenticateUser(username, password);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetrieveUserByUsernameReturnsCorrectUser()
        {
            // arrange
            const string expectedEmail = "test1@test.com";
            const string username = "test1";
            string actualEmail = "";

            // act
            var user = _userManager.RetrieveUserByUsername(username);
            actualEmail = user.Email;
            
            // assert
            Assert.AreEqual(expectedEmail, actualEmail);
            
        }

        [TestMethod][ExpectedException(typeof(ApplicationException))]
        public void TestRetrieveUserByUsernameFailsWithBadUser()
        {
            // arrange
            const string username = "abc";

            // act
            var user = _userManager.RetrieveUserByUsername(username);

            // assert: nothing to do

        }

        [TestMethod]
        public void TestUpdateAccountBioReturnsTrueForSuccess()
        {
            // arrange
            string username = "test1";
            string oldBio = "";
            string newBio = "This is a new bio.";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.UpdateAccountBio(username, oldBio, newBio);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }
       
        [TestMethod]
        public void TestUpdateAccountBioReturnsFalseForFailure()
        {
            // arrange
            string username = "test1";
            string oldBio = "abc";
            string newBio = "This is a new bio.";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.UpdateAccountBio(username, oldBio, newBio);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateUserEmailReturnsTrueForSuccess()
        {
            // arrange
            string username = "test1";
            string oldEmail = "test1@test.com";
            string newEmail = "test@test.com";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.UpdateAccountEmail(username, oldEmail, newEmail);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdateUserEmailReturnsFalseForBecauseBadEmail()
        {
            // arrange
            string username = "test1";
            string oldEmail = "test1.com";
            string newEmail = "test@test.com";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.UpdateAccountEmail(username, oldEmail, newEmail);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdateUserEmailReturnsFalseBecauseEmailInUse()
        {
            // arrange
            string username = "test1";
            string oldEmail = "test1@test.com";
            string newEmail = "test2@test.com";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.UpdateAccountEmail(username, oldEmail, newEmail);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdatePasswordReturnsTrueForSuccess()
        {
            // arrange
            string username = "test1";
            string email = "test1@test.com";
            string oldPassword = "password";
            string newPassword = "newpassword";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.UpdatePassword(username, email, oldPassword, newPassword);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdatePasswordReturnsFalseWithBadEmail()
        {
            // arrange
            string username = "test1";
            string email = "test@test.com";
            string oldPassword = "password";
            string newPassword = "newpassword";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.UpdatePassword(username, email, oldPassword, newPassword);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdatePasswordReturnsFalseWithBadOldPassword()
        {
            // arrange
            string username = "test1";
            string email = "test1@test.com";
            string oldPassword = "blahblahblah";
            string newPassword = "newpassword";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.UpdatePassword(username, email, oldPassword, newPassword);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCreateNewAccountReturnsTrueForSuccess()
        {
            // arrange
            string username = "test3";
            string email = "test3@test.com";
            string password = "password";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.CreateNewAccount(username, email, password);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestCreateNewAccountReturnsFalseBecauseUsedUsername()
        {
            // arrange
            string username = "test1";
            string email = "test3@test.com";
            string password = "password";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.CreateNewAccount(username, email, password);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCreateNewAccountReturnsFalseBecauseUsedEmail()
        {
            // arrange
            string username = "test3";
            string email = "test1@test.com";
            string password = "password";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.CreateNewAccount(username, email, password);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }





        [TestMethod]
        public void TestGetUserFriendStatusReturnsTrueForPending()
        {
            // arrange
            string user = "test1";
            string userFriend = "test4";
            var result = new UserFriend();
            const string expectedResult = "pending";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestGetUserFriendStatusRetursFalseForPending()
        {
            // arrange
            string user = "test1";
            string userFriend = "test5";
            var result = new UserFriend();
            const string expectedResult = "pending";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetUserFriendStatusReturnsTrueForWaiting()
        {
            // arrange
            string user = "test1";
            string userFriend = "test5";
            var result = new UserFriend();
            const string expectedResult = "waiting";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetUserFriendStatusReturnsFalseForWaiting()
        {
            // arrange
            string user = "test1";
            string userFriend = "test4";
            var result = new UserFriend();
            const string expectedResult = "waiting";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetUserFriendStatusReturnsTrueForFriend()
        {
            // arrange
            string user = "test1";
            string userFriend = "test6";
            var result = new UserFriend();
            const string expectedResult = "friend";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetUserFriendStatusReturnsFalseForFriend()
        {
            // arrange
            string user = "test1";
            string userFriend = "test4";
            var result = new UserFriend();
            const string expectedResult = "friend";
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [TestMethod][ExpectedException(typeof(NullReferenceException))]
        public void TestGetUserFriendStatusNotExists()
        {
            // arrange
            string user = "test5";
            string userFriend = "test6";
            var result = new UserFriend();
            
            string actualResult = null;

            // act
            result = _userManager.RetrieveFriendStatus(user, userFriend);
            actualResult = result.UserFriendStatus;

            // assert: nothing to do
            
        }


        [TestMethod]
        public void TestSendFriendRequestsReturnsTrueForSuccess()
        {
            // arrange
            string user = "test4";
            string otherUser = "test5";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.SendFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // another test?

        [TestMethod]
        public void TestGetFriendListByUser()
        {
            // arrange
            List<UserFriend> friends = new List<UserFriend>();
            string user = "test1";
            int expectedResult = 1;
            int actualResult = 0;

            // act
            friends = _userManager.RetrieveFriendList(user);
            actualResult = friends.Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestGetPendingFriendRequestListByUser()
        {
            // arrange
            List<UserFriend> friends = new List<UserFriend>();
            string user = "test1";
            int expectedResult = 1;
            int actualResult = 0;

            // act
            friends = _userManager.RetrievePendingFriendRequests(user);
            actualResult = friends.Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestGetWaitingFriendRequestListByUser()
        {
            // arrange
            List<UserFriend> friends = new List<UserFriend>();
            string user = "test1";
            int expectedResult = 1;
            int actualResult = 0;

            // act
            friends = _userManager.RetrieveFriendRequests(user);
            actualResult = friends.Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void TestCancelPendingFriendRequestReturnsTrueForSuccess()
        {
            // arrange
            string user = "test1";
            string otherUser = "test4";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.CancelPendingFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestCancelPendingFriendRequestReturnsFalseForFailure()
        {
            // arrange
            string user = "test1";
            string otherUser = "test5";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.CancelPendingFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRemoveFriendReturnsTrueForSuccess()
        {
            // arrange
            string user = "test1";
            string otherUser = "test6";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.RemoveFriend(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveFriendReturnsFalseForFailure()
        {
            // arrange
            string user = "test1";
            string otherUser = "test5";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.RemoveFriend(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRejectFriendRequestReturnsTrueForSuccess()
        {
            // arrange
            string user = "test1";
            string otherUser = "test5";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.RejectFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRejectFriendRequestReturnsFalseForFailure()
        {
            // arrange
            string user = "test1";
            string otherUser = "test6";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.RejectFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAcceptFriendRequestReturnsTrueForSuccess()
        {
            // arrange
            string user = "test1";
            string otherUser = "test5";
            const bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _userManager.AcceptFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestAcceptFriendRequestReturnsFalseForFailure()
        {
            // arrange
            string user = "test1";
            string otherUser = "test6";
            const bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _userManager.AcceptFriendRequest(user, otherUser);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void TestSelectAllUsers()
        {
            // arrange
            int expectedCount = 5;
            int actualCount = 0;

            // act
            actualCount = _userManager.SelectAllUsers().Count();

            // assert
            Assert.AreEqual(expectedCount, actualCount);

        }

        
        [TestMethod]
        public void TestSelectUserByEmailIsSuccessful()
        {
            // arrange
            string email = "test1@test.com";
            string expectedUsername = "test1";
            string actualUsername = "";

            // act
            actualUsername = _userManager.SelectUserByEmail(email).Username;

            // assert
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [TestMethod][ExpectedException(typeof(NullReferenceException))]
        public void TestSelectUserByEmailFailsWithInvalidEmail()
        {
            // arrange
            string email = "test3@test.com";
            string username = "test3";

            // act
            username = _userManager.SelectUserByEmail(email).Username;

            // assert not needed
        }


    }
}