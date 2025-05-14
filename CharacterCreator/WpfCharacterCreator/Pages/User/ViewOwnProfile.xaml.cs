using Azure.Core;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCharacterCreator.Pages.User
{
    /// <summary>
    /// Interaction logic for ViewOwnProfile.xaml
    /// </summary>
    public partial class ViewOwnProfile : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager(); 
        DataDomain.User user = null;
        public ViewOwnProfile()
        {
            InitializeComponent();
            user = _userManager.RetrieveUserByUsername(main.Username);

            lblUserProfileUsername.Content = user.Username;
            txtUserProfileEmail.Text = user.Email;
            txtUserProfileBio.Text = user.AccountBio;

            txtUserProfileBio.IsEnabled = false;
            txtUserProfileEmail.IsEnabled = false;

            btnChangePassword.Visibility = Visibility.Hidden;
            btnUserProfileSaveChanges.Visibility = Visibility.Hidden;
        }
        private void btnUserProfileSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            DataDomain.User _accessToken = _userManager.RetrieveUserByUsername(main.Username);

            string username = _accessToken.Username;
            string oldEmail = _accessToken.Email;
            string newEmail = txtUserProfileEmail.Text;
            string oldBio = _accessToken.AccountBio;
            string newBio = txtUserProfileBio.Text;
            try
            {
                if (newBio.Length > 500) // check if bio is too long
                {
                    txtUserProfileBio.Focus();
                    throw new Exception("Bio cannot be more than 500 characters.");
                }
                else if (!main.CheckEmailFormat(newEmail)) // check if email is valid
                {
                    txtUserProfileEmail.Focus();
                    throw new Exception("Invalid email address format.");
                }
                else if (newEmail.Length > 100) // check if email is too long
                {
                    txtUserProfileEmail.Focus();
                    throw new Exception("Email cannot be more than 100 characters.");
                }
                else
                { 
                    if (oldEmail != newEmail)
                    {
                        _userManager.UpdateAccountEmail(username, oldEmail, newEmail);

                    }
                    if (oldBio != newBio)
                    {
                        _userManager.UpdateAccountBio(username, oldBio, newBio);
                    }
                    _accessToken = _userManager.RetrieveUserByUsername(_accessToken.Username);
                    main.UserChanged(_accessToken);
                    main.ShowMessage("Account Updated", "Your account was updated", "Success");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Profile", ex.Message, "Error");
            }
        }

        private void btnUserProfileEditProfile_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            txtUserProfileEmail.IsEnabled = true;
            txtUserProfileBio.IsEnabled = true;

            btnUserProfileEditProfile.Visibility = Visibility.Hidden;
            btnUserProfileSaveChanges.Visibility = Visibility.Visible;
            btnChangePassword.Visibility = Visibility.Visible;
        }
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            NavigationService.GetNavigationService(this).Navigate(new ChangePassword());
        }

    }
}
