using DataDomain;
using LogicLayer;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WpfCharacterCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hideAll();
            gridHeader.Visibility = Visibility.Hidden;
            gridLogin.Visibility = Visibility.Visible;
        }

        User _accessToken = null;
        UserCharacter _currentCharacter = null;

        UserManager _userManager = new UserManager();
        CharacterManager _characterManager = new CharacterManager();

        List<UserFriend> userFriends = new List<UserFriend>();
        List<UserFriend> waitingRequests = new List<UserFriend>();
        List<UserFriend> pendingRequests = new List<UserFriend>();

        List<UserCharacter> userCharacters = new List<UserCharacter>();
        List<UserPermission> sharedCharacters = new List<UserPermission>();

        List<Trait> traits = new List<Trait>();
        List<CharacterTraitVM> characterTraits = new List<CharacterTraitVM>();
        List<Trait> traitCharacter = new List<Trait>();

        List<Skill> skills = new List<Skill>();
        List<CharacterSkill> characterSkills = new List<CharacterSkill>();

        List<CharacterLikeDislike> allInterests = new List<CharacterLikeDislike>();
        List<CharacterLikeDislike> characterLikes = new List<CharacterLikeDislike>();
        List<CharacterLikeDislike> characterDislikes = new List<CharacterLikeDislike>();

        bool selection = true;

        private bool checkEmailFormat(string email)
        {
            bool result = false;

            // regular expression code source:
            // https://stackoverflow.com/questions/5342375/regex-email-validation
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (match.Success)
            {
                result = true;
            }

            return result;
        }

        private void errorMessage(string error, string message)
        {
            hideFooter();
            lblErrorHeader.Content = error;
            lblErrorMessage.Content = message + ".";
            lblErrorHeader.Visibility = Visibility.Visible;
            lblErrorMessage.Visibility = Visibility.Visible;
        }
        private void successMessage(string success, string message)
        {
            hideFooter();
            lblSuccessHeader.Content = success;
            lblSuccessMessage.Content = message + ".";
            lblSuccessHeader.Visibility = Visibility.Visible;
            lblSuccessMessage.Visibility = Visibility.Visible;
        }

        private void hideFooter()
        {
            lblErrorHeader.Visibility = Visibility.Hidden;
            lblErrorMessage.Visibility = Visibility.Hidden;
            lblSuccessHeader.Visibility = Visibility.Hidden;
            lblSuccessMessage.Visibility = Visibility.Hidden;
        }
        private void hideAll()
        {
            hideFooter();

            txtUsername.Clear();
            pwdPassword.Clear();
            userFriends.Clear();
            waitingRequests.Clear();
            pendingRequests.Clear();
            txtInsertUsername.Clear();
            txtInsertEmail.Clear();
            pwdChoosePassword.Clear();
            pwdVerifyPassword.Clear();

            gridLogin.Visibility = Visibility.Hidden;
            gridCreateAccount.Visibility = Visibility.Hidden;
            gridUserProfile.Visibility = Visibility.Hidden;
            gridEditProfileButton.Visibility = Visibility.Hidden;
            gridSaveProfileButton.Visibility = Visibility.Hidden;
            gridChangePassword.Visibility = Visibility.Hidden;
            gridFriends.Visibility = Visibility.Hidden;
            gridOtherUserProfile.Visibility = Visibility.Hidden;
            gridFriendRequestOptions.Visibility = Visibility.Hidden;
            btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Hidden;
            btnOtherUserCancelFriendRequest.Visibility = Visibility.Hidden;
            btnOtherUserUnfriend.Visibility = Visibility.Hidden;
            gridAcceptOrDenyFriendRequest.Visibility = Visibility.Hidden;
            gridCharacterLists.Visibility = Visibility.Hidden;
            gridCreateNewCharacter.Visibility = Visibility.Hidden;
            gridCharacterProfile.Visibility = Visibility.Hidden;
            gridEditCharacter.Visibility = Visibility.Hidden;
            gridShareCharacter.Visibility = Visibility.Hidden;

        }
        private void showHeaderBar()
        {
            gridHeader.Visibility = Visibility.Visible;
            if (_accessToken != null)
            {
                btnUsername.Content = "@" + _accessToken.Username;
            }
        }


        /*
            Login Methods 
        */
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            string username = txtUsername.Text;
            string password = pwdPassword.Password;

            if (username == "") // check if username is blank
            {
                errorMessage("Invalid Username", "Username Cannot be Empty");
                txtUsername.Focus();
            }
            else if (password == "") // check if password is blank
            {
                errorMessage("Invalid Password", "Password Cannot be Empty");
                pwdPassword.Focus();
            }
            else
            {
                try
                {
                    _accessToken = _userManager.LogInUser(username, password);
                    if (_accessToken != null)
                    {
                        hideAll();
                        showUserProfile();
                        showHeaderBar();
                    }
                    else
                    {
                        errorMessage("Invalid Information", "Bad Username or Password");
                    }
                }
                catch (Exception)
                {
                    errorMessage("Invalid Information", "Bad Username or Password");
                }
            }
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult logoutConfirmation =
                MessageBox.Show("Are you sure you want to log out?", "Log Out?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (logoutConfirmation == MessageBoxResult.Yes)
            {
                _accessToken = null;
                hideAll();
                gridHeader.Visibility = Visibility.Hidden;
                gridLogin.Visibility = Visibility.Visible;
            }
            else
            {
                return;
            }

        }
        private void btnCreateNewAccount_Click(object sender, RoutedEventArgs e)
        {
            hideAll();

            txtInsertUsername.Clear();
            txtInsertEmail.Clear();
            pwdChoosePassword.Clear();
            pwdVerifyPassword.Clear();

            gridCreateAccount.Visibility = Visibility.Visible;
        }
        private void btnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            gridLogin.Visibility = Visibility.Visible;
        }
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            string username = txtInsertUsername.Text;
            string email = txtInsertEmail.Text;
            string password = pwdChoosePassword.Password;
            string passwordVerified = pwdVerifyPassword.Password;

            if (username == "") // check if username is blank
            {
                errorMessage("Invalid Username", "Username Cannot be Empty");
                txtInsertUsername.Focus();
            }
            else if (username.Length > 20) // check if username is too long
            {
                errorMessage("Invalid Username", "Username Cannot be More Than 20 Characters");
                txtInsertUsername.Focus();
            }
            else if (email == "") // check if email is blank
            {
                errorMessage("Invalid Email", "Email Cannot be Empty");
                txtInsertEmail.Focus();
            }
            else if (email.Length > 100) // check if email is too long
            {
                errorMessage("Invalid Email", "Email Cannot be More Than 100 Characters");
                txtInsertEmail.Focus();
            }
            else if (!checkEmailFormat(email)) // check if email is valid
            {
                errorMessage("Invalid Email", "Incorrect Email Format.");
                txtInsertEmail.Focus();
            }
            else if (password == "") // check if password is blank
            {
                errorMessage("Invalid Password", "Password Cannot be Empty");
                pwdChoosePassword.Focus();
            }
            else if (password.Length > 100) // check if password is too long
            {
                errorMessage("Invalid Password", "Password Cannot be More Than 100 Characters");
                pwdChoosePassword.Focus();
            }
            else if (password != passwordVerified) // check if passwords are different
            {
                errorMessage("Invalid Password", "Passwords Must Match");
                pwdVerifyPassword.Focus();
            }
            else
            {
                try
                {
                    if (_userManager.CreateNewAccount(username, email, password))
                    {
                        _accessToken = _userManager.LogInUser(username, password);
                        hideAll();
                        showHeaderBar();
                        showUserProfile();
                    }
                    else
                    {
                        errorMessage("Invalid Username or Email", "The Username or Email is Already Taken");
                    }
                }
                catch (Exception ex)
                {
                    errorMessage("Error Creating Account", "There Was an Error Creating The Account");
                }
            }
        }


        /*
            User Profile Methods
        */
        private void showUserProfile()
        {
            if (_accessToken != null)
            {
                gridUserProfile.Visibility = Visibility.Visible;
                gridEditProfileButton.Visibility = Visibility.Visible;

                lblUserProfileUsername.Content = _accessToken.Username;
                txtUserProfileEmail.Text = _accessToken.Email;
                txtUserProfileBio.Text = _accessToken.AccountBio;

                txtUserProfileEmail.IsEnabled = false;
                txtUserProfileBio.IsEnabled = false;
            }
            else
            {
                hideAll();
                gridHeader.Visibility = Visibility.Hidden;
                errorMessage("Error", "An Unexpected Error has Occured");
                gridLogin.Visibility = Visibility.Visible;
            }
        }
        private void btnUsername_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            showUserProfile();
        }
        private void btnUserProfileEditProfile_Click(object sender, RoutedEventArgs e)
        {
            txtUserProfileEmail.IsEnabled = true;
            txtUserProfileBio.IsEnabled = true;

            hideFooter();

            gridEditProfileButton.Visibility = Visibility.Hidden;
            gridSaveProfileButton.Visibility = Visibility.Visible;
        }
        private void btnUserProfileSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string username = _accessToken.Username;
            string oldEmail = _accessToken.Email;
            string newEmail = txtUserProfileEmail.Text;
            string oldBio = _accessToken.AccountBio;
            string newBio = txtUserProfileBio.Text;

            if (newBio.Length > 500) // check if bio is too long
            {
                errorMessage("Invalid Bio", "Bio Cannot be More Than 500 Characters");
                txtUserProfileBio.Focus();
            }
            else if (!checkEmailFormat(newEmail)) // check if email is valid
            {
                errorMessage("Invalid Email", "Email Must be in Correct Email Format");
                txtUserProfileEmail.Focus();
            }
            else if (newEmail.Length > 100) // check if email is too long
            {
                errorMessage("Invalid Email", "Email Cannot be More Than 100 Characters");
                txtUserProfileEmail.Focus();
            }

            else if (oldEmail == newEmail && oldBio == newBio)
            {
                hideAll();
                showUserProfile();
            }
            else
            {
                try
                {
                    if (oldEmail != newEmail)
                    {
                        _userManager.UpdateAccountEmail(username, oldEmail, newEmail);
                    }
                    if (_userManager.UpdateAccountBio(username, oldBio, newBio))
                    {
                        _accessToken.AccountBio = newBio;
                        _accessToken.Email = newEmail;
                        hideAll();
                        showUserProfile();
                        successMessage("Update Successful", "Account Was Updated Successfully");
                    }
                    else
                    {
                        errorMessage("Update Failed", "There was an Error Updating The Profile");
                    }
                }
                catch (Exception)
                {
                    errorMessage("Invalid Email", "Email is Already Taken");
                    txtUserProfileEmail.Focus();
                }
            }
        }
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            gridHeader.Visibility = Visibility.Hidden;
            gridChangePassword.Visibility = Visibility.Visible;
        }
        private void btnChangePasswordCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
                MessageBox.Show("Are you sure you want to cancel your password change?\n\nYour changes will be lost.",
                                "Cancel Password Change.",
                                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                hideAll();
                showUserProfile();
                showHeaderBar();
            }

        }
        private void btnChangePasswordConfirm_Click(object sender, RoutedEventArgs e)
        {
            var userManager = new UserManager();
            string username = _accessToken.Username;
            string email = txtChangePasswordEmail.Text;
            string oldPassword = pwdOldPassword.Password;
            string newPassword = pwdNewPassword.Password;
            string verifyNewPassword = pwdConfrimNewPassword.Password;

            if (email == "")
            {
                errorMessage("Invalid Email", "Email Cannot be Empty");
                txtChangePasswordEmail.Focus();
            }
            else if (oldPassword == "")
            {
                errorMessage("Invalid Password", "Password Cannot be Empty");
                pwdOldPassword.Focus();
            }
            else if (newPassword == "")
            {
                errorMessage("Invalid Password", "Password Cannot be Empty");
                pwdNewPassword.Focus();
            }
            else if (newPassword.Length > 100)
            {
                errorMessage("Invalid Password", "Password Cannot be More Than 100 Characters");
                pwdNewPassword.Focus();
            }
            else if (newPassword != verifyNewPassword)
            {
                errorMessage("Invalid Password", "New Password Must Match Verified Password");
                pwdVerifyPassword.Focus();
            }
            else if (_accessToken.Email != email)
            {
                errorMessage("Invalid Email", "Incorrect Email Entered");
                txtChangePasswordEmail.Focus();
            }
            else
            {
                try
                {
                    if (!userManager.AuthenticateUser(username, oldPassword))
                    {
                        errorMessage("Incorrect Password", "The Password for This Account is Incorrect");
                        pwdOldPassword.Focus();
                    }
                    else
                    {
                        if (userManager.UpdatePassword(username, email, oldPassword, newPassword))
                        {
                            hideAll();
                            showUserProfile();
                            showHeaderBar();
                            successMessage("Update Successful", "Your Password Has Now Been Updated");
                        }
                        else
                        {
                            errorMessage("Error Occured", "There Was an Error Changing The Password");
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        /*
            Friend Methods
        */
        private void updateFriends()
        {
            string username = _accessToken.Username;

            // get different relationships to user
            userFriends = _userManager.RetrieveFriendList(username);
            waitingRequests = _userManager.RetrieveFriendRequests(username);
            pendingRequests = _userManager.RetrievePendingFriendRequests(username);

            // have the tab headers show how many in each section
            tabFriends.Header = "My Friends (" + userFriends.Count + ")";
            tabWaiting.Header = "Friend Requests (" + waitingRequests.Count + ")";
            tabPending.Header = "Pending Requests (" + pendingRequests.Count + ")";

            // display friend lists
            listFriends.ItemsSource = userFriends;
            listWaiting.ItemsSource = waitingRequests;
            listPending.ItemsSource = pendingRequests;
        }
        private void showFriends()
        {
            gridFriends.Visibility = Visibility.Visible;
            tabFriendOptions.SelectedIndex = 0;

            try
            {
                updateFriends();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }
        private void showOtherUserProfile(User otherUser)
        {
            gridOtherUserProfile.Visibility = Visibility.Visible;
            gridFriendRequestOptions.Visibility = Visibility.Visible;

            string otherUsername = otherUser.Username;
            lblOtherUserProfileUsername.Content = otherUsername;
            lblOtherUserFriendStatus.Content = "";

            txtSearchUsers.Clear();

            if (otherUser.AccountBio != "")
            {
                txtOtherUserProfileBio.Text = otherUser.AccountBio;
            }
            else
            {
                txtOtherUserProfileBio.Text = otherUser.Username + " has not made a bio yet.";
            }

            try
            {
                UserFriend friend = _userManager.RetrieveFriendStatus(_accessToken.Username, otherUser.Username);

                if (friend == null)
                {
                    btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Visible;
                }
                else
                {

                    if (friend.UserFriendStatus == "friend")
                    {
                        lblOtherUserFriendStatus.Content = "Became Friends on " + friend.UserFriendDate;
                        btnOtherUserUnfriend.Visibility = Visibility.Visible;
                    }
                    else if (friend.UserFriendStatus == "pending")
                    {
                        lblOtherUserFriendStatus.Content = "You Have Sent a Friend Request to " + otherUsername;
                        btnOtherUserCancelFriendRequest.Visibility = Visibility.Visible;
                    }
                    else if (friend.UserFriendStatus == "waiting")
                    {
                        lblOtherUserFriendStatus.Content = otherUsername + " Has Sent You a Friend Request";
                        gridFriendRequestOptions.Visibility = Visibility.Hidden;
                        gridAcceptOrDenyFriendRequest.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                errorMessage("Error Occured", "An Unexpected Error Occured");
            }

            try
            {
                // imgOtherUserProfilePicture.Source = otherUser.ProfilePicture;
            }
            catch (Exception ex)
            {
                errorMessage("Error Occured", "An Unexpected Error Occured");
            }

        }
        private void btnFriends_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            showFriends();
        }
        private void btnViewFriendProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int friend = listFriends.SelectedIndex;
                string userFriend = userFriends[friend].UserFriendID;
                if (friend == null)
                {
                    errorMessage("No User Selected", "Select a User to View Their Profile");
                }
                else
                {
                    User user = _userManager.RetrieveUserByUsername(userFriend);
                    hideAll();
                    showOtherUserProfile(user);
                }

            }
            catch (Exception ex)
            {
                hideAll();
                showFriends();
                errorMessage("Error Loading Profile", "There Was an Error Loading Use Profile");
            }
        }
        private void btnViewWaitingProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int waiting = listWaiting.SelectedIndex;
                string userFriend = waitingRequests[waiting].UserFriendID;
                if (waiting == null)
                {
                    errorMessage("No User Selected", "Select a User to View Their Profile");
                }
                else
                {
                    User user = _userManager.RetrieveUserByUsername(userFriend);
                    hideAll();
                    showOtherUserProfile(user);
                }

            }
            catch (Exception ex)
            {
                hideAll();
                showFriends();
                errorMessage("Error Loading Profile", "There Was an Error Loading User Profile");
            }
        }
        private void btnViewPendingProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pending = listPending.SelectedIndex;
                string userFriend = pendingRequests[pending].UserFriendID;
                if (pending == null)
                {
                    errorMessage("No User Selected", "Select a User to View Their Profile");
                }
                else
                {
                    User user = _userManager.RetrieveUserByUsername(userFriend);
                    hideAll();
                    showOtherUserProfile(user);
                }

            }
            catch (Exception ex)
            {
                hideAll();
                showFriends();
                errorMessage("Error Loading Profile", "There Was an Error Loading User Profile");
            }
        }
        private void btnSearchUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager();
            User otherUser = null;
            string otherUsername = txtSearchUsers.Text;

            if (otherUsername == _accessToken.Username)
            {
                hideAll();
                showUserProfile();
                return;
            }
            try
            {
                otherUser = userManager.RetrieveUserByUsername(otherUsername);
                if (otherUser != null)
                {
                    hideAll();
                    showOtherUserProfile(otherUser);
                }
                else
                {
                    errorMessage("User Not Found", "Could Not Find a User Called " + otherUsername);
                    txtSearchUsers.Focus();
                }
            }
            catch (Exception ex)
            {
                errorMessage("User Not Found", "Could Not Find User");
            }

        }
        private void btnOtherUserProfileBack_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            showFriends();
        }
        private void btnOtherUserProfileSendFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            string user = _accessToken.Username;
            string otherUser = lblOtherUserProfileUsername.Content.ToString();

            try
            {
                User otherPerson = _userManager.RetrieveUserByUsername(otherUser);

                if (_userManager.SendFriendRequest(user, otherUser))
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
                else
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
            }
            catch (Exception ex)
            {
                hideAll();
                showFriends();

                MessageBox.Show("" + ex, "Error Sending Friend Request");
            }
        }
        private void btnOtherUserCancelFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            string user = _accessToken.Username;
            string otherUser = lblOtherUserProfileUsername.Content.ToString();

            try
            {
                User otherPerson = _userManager.RetrieveUserByUsername(otherUser);

                if (_userManager.CancelPendingFriendRequest(user, otherUser))
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
                else
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnOtherUserUnfriend_Click(object sender, RoutedEventArgs e)
        {
            string user = _accessToken.Username;
            string otherUser = lblOtherUserProfileUsername.Content.ToString();

            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove " + otherUser + " as a friend?",
                                                      "Remove Friend", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    User otherPerson = _userManager.RetrieveUserByUsername(otherUser);

                    if (_userManager.RemoveFriend(user, otherUser))
                    {
                        hideAll();
                        showOtherUserProfile(otherPerson);
                    }
                    else
                    {
                        hideAll();
                        showOtherUserProfile(otherPerson);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void btnOtherUserRejectFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            string user = _accessToken.Username;
            string otherUser = lblOtherUserProfileUsername.Content.ToString();

            try
            {
                User otherPerson = _userManager.RetrieveUserByUsername(otherUser);

                if (_userManager.RejectFriendRequest(user, otherUser))
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
                else
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnOtherUserAcceptFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            string user = _accessToken.Username;
            string otherUser = lblOtherUserProfileUsername.Content.ToString();

            try
            {
                User otherPerson = _userManager.RetrieveUserByUsername(otherUser);
                if (_userManager.AcceptFriendRequest(user, otherUser))
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
                else
                {
                    hideAll();
                    showOtherUserProfile(otherPerson);
                }
            }
            catch (Exception)
            {
                errorMessage("Error Accepting Friend Request", "There Was an Error Accepting The Friend Request.");
            }
        }


        /*
            Character Methods
        */
        // Character List Methods
        private void showCharacters()
        {
            gridCharacterLists.Visibility = Visibility.Visible;
            tabCharacterOptions.SelectedIndex = 0;

            try
            {
                userCharacters = _characterManager.GetCharactersByUser(_accessToken.Username);

                tabMyCharacters.Header = "My Characters (" + userCharacters.Count + ")";
                tabCharactersSharedWithMe.Header = "Shared With Me (" + sharedCharacters.Count + ")";

                listCharacters.ItemsSource = userCharacters;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                errorMessage("Error Loading Character List", "There Was an Error Loading The Character List");
            }
        }
        private void showSharedCharacters()
        {
            try
            {
                sharedCharacters = _characterManager.GetAccessCharactersByUser(_accessToken.Username);
                if (sharedCharacters.Count > 0)
                {
                    listSharedCharacters.ItemsSource = sharedCharacters;
                }
                tabCharactersSharedWithMe.Header = "Shared With Me (" + sharedCharacters.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                errorMessage("Error Loading Shared Character List", "There Was an Error Loading The Shared Character List");
            }
        }
        private void btnCharacters_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            hideFooter();
            showCharacters();
            showSharedCharacters();
        }


        // Character Profile Methods
        private void showCharacterProfile()
        {
            gridCharacterProfile.Visibility = Visibility.Visible;
            lblCreator.Visibility = Visibility.Hidden;
            hideFooter();
            try
            {
                // name
                string name = _currentCharacter.CharacterName;
                lblCharacterNameProfile.Content = name;

                string fullName = _currentCharacter.CharacterFirstName;
                if (_currentCharacter.CharacterMiddleName != null)
                {
                    fullName += " " + _currentCharacter.CharacterMiddleName;
                }
                if (_currentCharacter.CharacterLastName != null)
                {
                    fullName += " " + _currentCharacter.CharacterLastName;
                }
                lblCharacterFullName.Content = fullName;

                if (_currentCharacter.CreatorID == _accessToken.Username)
                {
                    btnShareCharacter.Visibility = Visibility.Visible;
                    btnEditCharacter.Visibility = Visibility.Visible;
                }
                else
                {
                    btnShareCharacter.Visibility = Visibility.Hidden;
                    btnEditCharacter.Visibility = Visibility.Hidden;
                    lblCreator.Visibility = Visibility.Visible;
                    lblCreator.Content = "You do not have access to " + _currentCharacter.CharacterName + ".";
                    bool access = false;
                    foreach (UserPermission permission in sharedCharacters)
                    {
                        if (permission.AccessType == "Editor" && permission.CharacterID == _currentCharacter.CharacterID)
                        {
                            btnEditCharacter.Visibility = Visibility.Visible;
                            lblCreator.Content = "You are an\nEditor for\n" + _currentCharacter.CreatorID + "'s\nCharacter.";
                            access = true;
                            break;
                        }
                        else if (permission.AccessType == "Viewer" && permission.CharacterID == _currentCharacter.CharacterID)
                        {
                            access = true;
                            lblCreator.Content = "You are a\nViewer for\n" + _currentCharacter.CreatorID + "'s\nCharacter.";
                            break;
                        }
                    }
                    if (!access)
                    {
                        errorMessage("Invalid Access Type", "The Access Type is Invalid");
                    }
                }

                // traits
                updateTraits();
                if (traitCharacter.Count == 0)
                {
                    textTraits.Text = name + " has no traits.";
                }
                else
                {
                    textTraits.Text = name + " is...\n\n\n";
                    foreach (Trait trait in traitCharacter)
                    {
                        textTraits.Text += trait.TraitID + ": " + trait.TraitDescription + "\n\n";
                    }
                }

                // skills
                updateSkills();
                if (characterSkills.Count == 0)
                {
                    textSkills.Text = name + " has no skills.";
                }
                else
                {
                    textSkills.Text = name + " is skilled with...\n\n\n";
                    foreach (CharacterSkill skill in characterSkills)
                    {
                        textSkills.Text += skill.SkillID + ": " + skill.CharacterSkillDescription + "\n\n";
                    }
                }

                // interests
                updateInterests();
                if (characterLikes.Count == 0)
                {
                    lblLikes.Content = "";
                    textLikes.Text = name + " doesn't like anything.";
                }
                else
                {
                    lblLikes.Content = name + " Likes...\n\n\n";
                    textLikes.Text = "";
                    foreach (CharacterLikeDislike like in characterLikes)
                    {
                        textLikes.Text += like.CharacterInterest + ": " + like.CharacterLikeDislikeDescription + "\n\n";
                    }
                }
                if (characterDislikes.Count == 0)
                {
                    lblDislikes.Content = "";
                    textDislikes.Text = name + " doesn't dislike anything.";
                }
                else
                {
                    lblDislikes.Content = name + " Dislikes...\n\n\n";
                    textDislikes.Text = "";
                    foreach (CharacterLikeDislike like in characterDislikes)
                    {
                        textDislikes.Text += like.CharacterInterest + ": " + like.CharacterLikeDislikeDescription + "\n\n";
                    }
                }

            }
            catch (Exception ex)
            {
                hideAll();
                errorMessage("Error Loading Character", "There Was an Error Loading The Profile for " + _currentCharacter.CharacterName);
                showCharacters();
            }
        }
        private void btnViewCharacterProfile_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int character = listCharacters.SelectedIndex;
                if (character == null)
                {
                    errorMessage("Invalid Character", "Select a Character to View Its Profile");
                }
                else
                {
                    _currentCharacter = userCharacters[character];
                    hideAll();
                    showCharacterProfile();
                }
            }
            catch (Exception ex)
            {
                errorMessage("Invalid Character", "Select a Character to View Its Profile");
            }
        }
        private void btnViewSharedCharacterProfile_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            int character = listSharedCharacters.SelectedIndex;
            if (character == null)
            {
                errorMessage("Invalid Shared Character", "Select a Shared Character to View Its Profile");
            }
            else
            {
                try
                {
                    _currentCharacter = _characterManager.GetCharacterByCharacterID(sharedCharacters[character].CharacterID);
                    hideAll();
                    showCharacterProfile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    errorMessage("Error Showing Shared Character Profile", "There Was an Error Showing the Profile of the Shared Character");
                }
            }
        }


        // Create New Character Methods
        private void btnCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            hideFooter();
            txtPickNameForNewCharacter.Clear();
            gridCreateNewCharacter.Visibility = Visibility.Visible;
        }
        private void btnCancelCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            hideFooter();
            showHeaderBar();
            showCharacters();
        }
        private void btnCreateCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            string name = txtPickNameForNewCharacter.Text;

            if (name == "")
            {
                errorMessage("Invalid Name", "Name Cannot be Empty");
            }
            else if (name.Length > 50)
            {
                errorMessage("Invalid Name", "Name Must Be 50 Characters or Less");
            }
            else
            {
                try
                {
                    UserCharacter newCharacter = new UserCharacter()
                    {
                        CreatorID = _accessToken.Username,
                        CharacterName = name
                    };
                    _characterManager.CreateNewCharacter(newCharacter);
                    userCharacters.Clear();
                    userCharacters = _characterManager.GetCharactersByUser(_accessToken.Username);
                    _currentCharacter = userCharacters[userCharacters.Count - 1];
                    hideAll();
                    showCharacterProfile();

                }
                catch (Exception ex)
                {
                    errorMessage("Error", "An Unexpected Error Occured");
                }
            }
        }


        // Update Character Methods
        private void showEditCharacter()
        {
            gridEditCharacter.Visibility = Visibility.Visible;
            btnShareCharacter.Visibility = Visibility.Visible;
            btnEditCharacter.Visibility = Visibility.Visible;
            tabDeactivateCharacter.Visibility = Visibility.Visible;
            tabEditCharacter.SelectedIndex = 0;

            txtCharacterName.Text = _currentCharacter.CharacterName;
            txtFirstName.Text = _currentCharacter.CharacterFirstName;
            txtMiddleName.Text = _currentCharacter.CharacterMiddleName;
            txtLastName.Text = _currentCharacter.CharacterLastName;

            pwdDeactivateCharacter.Clear();

            if (_accessToken.Username != _currentCharacter.CreatorID)
            {
                btnShareCharacter.Visibility = Visibility.Hidden;
                btnEditCharacter.Visibility = Visibility.Hidden;
                tabDeactivateCharacter.Visibility = Visibility.Hidden;
            }

            updateTraits();
            updateSkills();
            updateInterests();

        }
        private void btnEditCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            hideFooter();
            showEditCharacter();
        }
        private void btnUpdateIdentity_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            gridEditCharacter.Visibility = Visibility.Visible;
            string newName = txtCharacterName.Text;

            if (newName == "")
            {
                newName = _currentCharacter.CharacterName;
            }

            string newFirstName = (txtFirstName.Text == "" ? null : txtFirstName.Text);
            string newMiddleName = (txtMiddleName.Text == "" ? null : txtMiddleName.Text);
            string newLastName = (txtLastName.Text == "" ? null : txtLastName.Text);

            try
            {
                if (_characterManager.UpdateCharacter(_currentCharacter, newName, newFirstName, newMiddleName, newLastName))
                {
                    _currentCharacter = _characterManager.GetCharacterByCharacterID(_currentCharacter.CharacterID);
                    hideAll();
                    showCharacterProfile();
                    successMessage("Update Success", "Character Was Updated Successfully");
                }
                else
                {
                    errorMessage("Error Updating Character", "There Was an Error Updating The Character");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                errorMessage("Error Updating Character", "There Was an Error Updating " + _currentCharacter.CharacterName);
            }

        }
        private void btnCancelUpdateCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            MessageBoxResult result = MessageBox.Show("Are you sure you want to discard your changes?", "Discard Changes?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                hideAll();
                showCharacterProfile();
            }
        }
        private void btnDeactivateCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            string password = pwdDeactivateCharacter.Password;

            try
            {
                if (_userManager.AuthenticateUser(_accessToken.Username, password))
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to deactivate this character.\nThis can NOT be undone!", "Deactive Character?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (_characterManager.DeactivateCharacter(_accessToken.Username, _currentCharacter.CharacterID, _currentCharacter.CharacterName))
                        {
                            hideAll();
                            showCharacters();
                            successMessage("Character Deactivated", _currentCharacter.CharacterName + "Was Deactivated");
                            _currentCharacter = null;
                        }
                        else
                        {
                            errorMessage("Error Deactivating Character", "There Was an Error Deactivating The Character");
                        }
                    }
                }
                else
                {
                    errorMessage("Invalid Password", "The Password Entered is Not Correct");
                    pwdDeactivateCharacter.Focus();
                }
            }
            catch (Exception ex)
            {
                errorMessage("Error Deactivating Character", "There Was an Error Deactivating The Character");
            }

        }


        // Share Character Methods
        private void btnShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();
            hideAll();
            gridShareCharacter.Visibility = Visibility.Visible;

            lblShareCharacterName.Content = "Share " + _currentCharacter.CharacterName;
            try
            {
                updateFriends();

                comboFriendShare.Items.Clear();
                foreach (UserFriend friend in userFriends)
                {
                    comboFriendShare.Items.Add(friend.UserFriendID);
                }
            }
            catch (Exception ex)
            {
                hideAll();
                showCharacterProfile();
                errorMessage("Error Loading Share Character", "There Was an Error Loading The Share Character Page");
            }
        }
        private void btnCancelShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideAll();
            hideFooter();
            showCharacterProfile();
        }
        private void btnConfirmShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            string friend = comboFriendShare.Text;
            string access = comboAccessType.Text;

            if (friend == "" || friend == null)
            {
                errorMessage("Invalid User", "Select a User from your Friends List to Share Your Character With");
                comboFriendShare.Focus();
            }
            else if (access == "" || access == null)
            {
                errorMessage("Invalid Access Type", "Access Type Cannot be Blank");
                comboAccessType.Focus();
            }
            else
            {
                try
                {
                    List<UserPermission> permissions = _characterManager.GetAccessCharactersByUser(friend);
                    bool inUse = false;
                    foreach (UserPermission permission in permissions)
                    {
                        if (permission.CharacterID == _currentCharacter.CharacterID)
                        {
                            inUse = true;
                        }
                    }
                    if (!inUse)
                    {
                        if (_characterManager.GiveAccessToCharacter(friend, _currentCharacter.CreatorID, _currentCharacter.CharacterID, access))
                        {
                            hideAll();
                            successMessage("Character Shared", friend + " is now a " + access + " " + _currentCharacter.CharacterName + ".");
                            showCharacterProfile();
                        }
                        else
                        {
                            errorMessage("Error Sharing Character", "There was an Error Sharing The Character");
                        }
                    }
                    else
                    {
                        errorMessage("User Already Has Access", "This Character has Already Been Shared with " + friend);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    errorMessage("Error Sharing Character", "An Unexpected Error Prevented The Character from Being Shared");
                }
            }

        }


        // Character Trait Methods
        private void updateTraits()
        {
            try
            {
                characterTraits = _characterManager.GetAllTraitsForCharacter(_currentCharacter.CharacterID);
                traits = _characterManager.GetAllTraits();
                traitCharacter.Clear();

                foreach (CharacterTrait characterTrait in characterTraits)
                {
                    foreach (Trait trait in traits)
                    {
                        if (characterTrait.TraitID == trait.TraitID)
                        {
                            traitCharacter.Add(trait);
                        }
                    }
                }

                listCharacterTraits.ItemsSource = traits;
                listCharacterTraits.ItemsSource = traitCharacter;

                listTraits.ItemsSource = traitCharacter;
                listTraits.ItemsSource = traits;

            }
            catch (Exception ex)
            {
                errorMessage("Error Updating Traits", "There Was an Error Updating The Character's Traits");
            }

        }
        private void btnAddTrait_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int trait = listTraits.SelectedIndex;
                string traitName = traits[trait].TraitID;

                bool duplicate = false;

                foreach (CharacterTrait characterTrait in characterTraits)
                {
                    if (characterTrait.TraitID == traitName)
                    {
                        duplicate = true;
                    }
                }

                if (duplicate)
                {
                    errorMessage("Duplicate Trait", _currentCharacter.CharacterName + " Already Has The Trait " + traitName);
                }
                else
                {
                    if (_characterManager.AddTraitToCharacter(_currentCharacter.CharacterID, traitName))
                    {
                        updateTraits();
                        successMessage("Trait Added", traitName + " Was Added to " + _currentCharacter.CharacterName);
                    }
                    else
                    {
                        errorMessage("Error Adding Trait", "There Was an Error Adding The Trait");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage("Error Adding Trait", "There Was an Error Adding The Trait to The Character");
            }
        }
        private void btnRemoveTrait_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int trait = listCharacterTraits.SelectedIndex;
                string traitName = traitCharacter[trait].TraitID;

                if (_characterManager.RemoveTraitFromCharacter(_currentCharacter.CharacterID, traitName))
                {
                    try
                    {
                        updateTraits();
                        successMessage("Trait Removed", traitName + " Was Removed from " + _currentCharacter.CharacterName);

                    }
                    catch (Exception)
                    {
                        errorMessage("Error Updating Traits", "There Was an Error Updating The Traits");
                    }
                }
                else
                {
                    errorMessage("Error Removing Trait", "There Was an Error Removing The Trait " + traitName);
                }


            }
            catch (Exception)
            {
                errorMessage("Error Removing Trait", "There Was an Error Removing The Trait");
            }
        }


        // Character Skills Methods
        private void updateSkills()
        {
            try
            {
                characterSkills = _characterManager.GetAllSkillsForCharacter(_currentCharacter.CharacterID);
                skills = _characterManager.GetAllSkills();

                // listCharacterSkills.ItemsSource = skills;
                listCharacterSkills.ItemsSource = characterSkills;

                listSkills.ItemsSource = skills;
            }
            catch (Exception)
            {
                errorMessage("Error Updating Skills", "There Was an Error Updating The Character's Skills");
            }
        }
        private void listCharacterSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int skill = listCharacterSkills.SelectedIndex;
                string skillDescription = characterSkills[skill].CharacterSkillDescription;
                textUpdateSkillDescription.Text = skillDescription;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int skill = listSkills.SelectedIndex;
                string skillName = skills[skill].SkillID;

                string skillDescription = textSkillDescription.Text.Trim();
                if (skillDescription == null)
                {
                    skillDescription = "";
                }

                bool duplicate = false;

                foreach (CharacterSkill characterSkill in characterSkills)
                {
                    if (characterSkill.SkillID == skillName)
                    {
                        duplicate = true;
                    }
                }

                if (duplicate)
                {
                    errorMessage("Duplicate Skill", _currentCharacter.CharacterName + " Already Has The Skill " + skillName);
                }
                else
                {
                    if (_characterManager.AddSkillToCharacter(_currentCharacter.CharacterID, skillName, skillDescription))
                    {
                        textSkillDescription.Clear();

                        updateSkills();
                        successMessage("Skill Added", skillName + " Was Added to " + _currentCharacter.CharacterName);
                    }
                    else
                    {
                        errorMessage("Error Adding Skill", "There Was an Error Adding The Skill");
                    }
                }
            }
            catch (Exception)
            {
                errorMessage("Error Adding Skill", "There Was an Error Adding The Skill");
            }
        }
        private void btnRemoveSkill_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int skill = listCharacterSkills.SelectedIndex;
                string skillName = characterSkills[skill].SkillID;

                if (_characterManager.RemoveSkillFromCharacter(_currentCharacter.CharacterID, skillName))
                {
                    updateSkills();
                    textUpdateSkillDescription.Clear();
                    successMessage("Skill Removed", skillName + " Was Removed from " + _currentCharacter.CharacterName);
                }
                else
                {
                    errorMessage("Error Removing Skill", "There Was an Error Removing The Skill " + skillName);
                }
            }
            catch (Exception)
            {
                errorMessage("Error Removing Skill", "There Was an Error Removing The Skill");
            }
        }
        private void btnUpdateSkill_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                int skill = listCharacterSkills.SelectedIndex;
                string skillName = characterSkills[skill].SkillID;
                string oldDescription = characterSkills[skill].CharacterSkillDescription;
                string newDescription = textUpdateSkillDescription.Text.Trim();

                if (_characterManager.UpdateSkillForCharacter(_currentCharacter.CharacterID, skillName, oldDescription, newDescription))
                {
                    updateSkills();
                    textUpdateSkillDescription.Clear();
                    successMessage("Skill Updated", skillName + " for " + _currentCharacter.CharacterName + " Was Updated");
                }
                else
                {
                    updateSkills();
                    errorMessage("Error Updating Skill", "There Was an Error Updating The Skill");
                }
            }
            catch (Exception)
            {
                errorMessage("Error Updating Skill", "There Was an Error Updating The Skill");
            }
        }


        // Character Interests Methods
        private void updateInterests()
        {

            textLikeDislike.Clear();
            textAddLikeDislikeDescription.Clear();
            textLikeDislikeDescription.Clear();

            characterLikes.Clear();
            characterDislikes.Clear();

            try
            {
                allInterests = _characterManager.GetAllInterestsForCharacter(_currentCharacter.CharacterID);
                foreach (CharacterLikeDislike characterLikeDislike in allInterests)
                {
                    if (characterLikeDislike.LikeDislikeType == "Like")
                    {
                        characterLikes.Add(characterLikeDislike);
                    }
                    else
                    {
                        characterDislikes.Add(characterLikeDislike);
                    }
                }

                listCharacterLikes.ItemsSource = characterDislikes;
                listCharacterDislikes.ItemsSource = characterLikes;

                listCharacterLikes.ItemsSource = characterLikes;
                listCharacterDislikes.ItemsSource = characterDislikes;
            }
            catch (Exception)
            {
                errorMessage("Error Updating Likes and Dislikes", "There was an Error Updating the Likes and Dislikes");
            }
        }
        private void btnRemoveInterest_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                string type = "Dislike";
                string interest = textLikeDislike.Text;
                string description = textLikeDislikeDescription.Text;

                if (btnUpdateInterest.Content == "Update Like")
                {
                    type = "Like";
                }

                if (_characterManager.RemoveInterestFromCharacter(_currentCharacter.CharacterID, type, interest, description))
                {
                    updateInterests();
                    successMessage(type + " Removed", "The " + type + " was Removed");
                }
                else
                {
                    errorMessage("Error Removing " + type, "There was an Error Removing the " + type);
                }

            }
            catch (Exception)
            {
                errorMessage("Error Removing Like or Dislike", "There was an Error Removing the Like or Dislike");
            }
        }
        private void btnUpdateInterest_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                string type = "";

                string newInterest = textLikeDislike.Text;
                string newDescription = textLikeDislikeDescription.Text;

                string oldInterest = newInterest;
                string oldDescription = newDescription;

                if (btnUpdateInterest.Content == "Update Like")
                {
                    type = "Like";
                    oldInterest = characterLikes[listCharacterLikes.SelectedIndex].CharacterInterest;
                    oldDescription = characterLikes[listCharacterLikes.SelectedIndex].CharacterLikeDislikeDescription;
                }
                else if (btnUpdateInterest.Content == "Update Dislike")
                {
                    type = "Dislike";
                    oldInterest = characterDislikes[listCharacterDislikes.SelectedIndex].CharacterInterest;
                    oldDescription = characterDislikes[listCharacterDislikes.SelectedIndex].CharacterLikeDislikeDescription;
                }
                else
                {
                    errorMessage("Invalid Selection", "");
                }

                if (newInterest != oldInterest)
                {

                }

                if (newInterest == "")
                {
                    errorMessage("", "");
                    textLikeDislike.Focus();
                }
                else if (newInterest.Length > 25)
                {
                    errorMessage("", "");
                    textLikeDislike.Focus();
                }
                else if (newDescription == "")
                {
                    errorMessage("", "");
                    textLikeDislikeDescription.Focus();
                }
                else if (newDescription.Length > 50)
                {
                    errorMessage("", "");
                    textLikeDislikeDescription.Focus();
                }
                else
                {
                    if (_characterManager.UpdateInterestForCharacter(_currentCharacter.CharacterID, type, oldInterest, newInterest, oldDescription, newDescription))
                    {
                        updateInterests();
                        successMessage(type + " Updated", "The " + type + " was Updated");
                    }
                    else
                    {
                        errorMessage("Error Updating " + type, "There was an Error Updating the " + type);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage("Error Updating Like or Dislike", "There was an Error Updating the Like or Dislike");
                MessageBox.Show(ex.Message);
            }
        }
        private void listCharacterDislikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hideFooter();

            if (selection)
            {
                selection = false;
                listCharacterLikes.SelectedItem = null;
                selection = true;

                try
                {
                    int dislike = listCharacterDislikes.SelectedIndex;
                    textLikeDislike.Text = characterDislikes[dislike].CharacterInterest;
                    textLikeDislikeDescription.Text = characterDislikes[dislike].CharacterLikeDislikeDescription;

                    btnUpdateInterest.Content = "Update Dislike";
                    btnRemoveInterest.Content = "Remove Dislike";
                }
                catch (Exception)
                {
                    errorMessage("", "");
                }
            }

        }
        private void listCharacterLikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            hideFooter();

            if (selection)
            {
                selection = false;
                listCharacterDislikes.SelectedItem = null;
                selection = true;

                try
                {
                    int like = listCharacterLikes.SelectedIndex;
                    textLikeDislike.Text = characterLikes[like].CharacterInterest;
                    textLikeDislikeDescription.Text = characterLikes[like].CharacterLikeDislikeDescription;

                    btnUpdateInterest.Content = "Update Like";
                    btnRemoveInterest.Content = "Remove Like";
                }
                catch (Exception)
                {
                    errorMessage("", "");
                }
            }

        }
        private void btnAddLikeOrDislike_Click(object sender, RoutedEventArgs e)
        {
            hideFooter();

            try
            {
                string type = comboLikeDislike.Text;
                string interest = textLikeDislikeName.Text;
                string description = textAddLikeDislikeDescription.Text;

                bool duplicate = false;

                foreach (CharacterLikeDislike value in allInterests)
                {
                    if (value.CharacterInterest == interest)
                    {
                        errorMessage("Duplicate Value", _currentCharacter.CharacterName + " Already " + value.LikeDislikeType + "s " + interest);
                        duplicate = true;
                    }
                }

                if (!duplicate)
                {
                    if (type != "Like" && type != "Dislike")
                    {
                        errorMessage("Invalid Selection", "There Needs to be a Like or Dislike Value.");
                        comboLikeDislike.Focus();
                    }
                    else if (interest == "")
                    {
                        errorMessage(type + " Cannot be Empty", "There Needs to be a Name for the " + type);
                        textLikeDislikeName.Focus();
                    }
                    else if (interest.Length > 25)
                    {
                        errorMessage(type + " is Too Long", "The " + type + " Cannot be More than 25 Characters");
                        textLikeDislikeName.Focus();
                    }
                    else if (description == "")
                    {
                        errorMessage("Description Cannot be Empty", "The Description Cannot be Empty");
                        textLikeDislikeName.Focus();
                    }
                    else if (description.Length > 50)
                    {
                        errorMessage("Description is Too Long", "The Description Cannot be More than 50 Characters");
                        textLikeDislikeName.Focus();
                    }

                    else
                    {
                        if (_characterManager.AddInterestToCharacter(_currentCharacter.CharacterID, type, interest, description))
                        {
                            textLikeDislikeName.Clear();
                            updateInterests();
                            successMessage(type + " was Added", "The " + type + " was Successfully Added");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage("Error Adding Like or Dislike", "There Was an Error Adding the Like or Dislike");
                MessageBox.Show(ex.Message);
            }
        }
    }
}