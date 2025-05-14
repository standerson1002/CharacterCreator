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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePasswordCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
                MessageBox.Show("Are you sure you want to cancel your password change?\n\nYour changes will be lost.",
                                "Cancel Password Change",
                                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                NavigationService.GetNavigationService(this).Navigate(new ViewOwnProfile());
            }
        }

        private void btnChangePasswordConfirm_Click(object sender, RoutedEventArgs e)
        {
            var userManager = new UserManager();
            string username = main.Username;
            string email = txtChangePasswordEmail.Text;
            string oldPassword = pwdOldPassword.Password;
            string newPassword = pwdNewPassword.Password;
            string verifyNewPassword = pwdConfrimNewPassword.Password;

            try
            {
                if (email == "")
                {
                    txtChangePasswordEmail.Focus();
                    throw new Exception("Email cannot be empty.");
                }
                else if (oldPassword == "")
                {
                    pwdOldPassword.Focus();
                    throw new Exception("Old password cannot be empty.");
                }
                else if (newPassword == "")
                {
                    pwdNewPassword.Focus();
                    throw new Exception("New password cannot be empty.");
                }
                else if (newPassword.Length > 100)
                {
                    pwdNewPassword.Focus();
                    throw new Exception("New Password cannot be more than 100 characters.");
                }
                else if (newPassword != verifyNewPassword)
                {
                    pwdConfrimNewPassword.Focus();
                    throw new Exception("Passwords do not match.");
                }
                else if (main.Email != email)
                {
                    txtChangePasswordEmail.Focus();
                    throw new Exception("Incorrect email address.");
                }
                else
                {

                    if (!userManager.AuthenticateUser(username, oldPassword))
                    {
                        pwdOldPassword.Focus();
                        throw new Exception("Incorrect old password.");
                    }
                    else
                    {
                        if (userManager.UpdatePassword(username, email, oldPassword, newPassword))
                        {
                            main.ShowMessage("Password Updated", "Your password was updated", "Success");
                            NavigationService.GetNavigationService(this).Navigate(new ViewOwnProfile());
                        }
                        else
                        {
                            throw new Exception("Password was not changed.");
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                main.ShowMessage("Error Changing Password", ex.Message, "Error");
            }
        }
    }
}
