using Azure.Core;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
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


namespace WpfCharacterCreator.Pages
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager();

        public Signup()
        {
            InitializeComponent();
        }

        private void btnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string username = txtInsertUsername.Text;
            string email = txtInsertEmail.Text;
            string password = pwdChoosePassword.Password;
            string passwordVerified = pwdVerifyPassword.Password;

            try
            {
                if (username == "") // check if username is blank
                {
                    txtInsertUsername.Focus();
                    throw new Exception("Username cannot be empty.");
                }
                else if (username.Length > 20) // check if username is too long
                {
                    txtInsertUsername.Focus();
                    throw new Exception("Username cannot be more than 20 characters.");
                }
                else if (email == "") // check if email is blank
                {
                    txtInsertEmail.Focus();
                    throw new Exception("Email cannot be empty.");
                }
                else if (email.Length > 100) // check if email is too long
                {
                    txtInsertEmail.Focus();
                    throw new Exception("Email cannot be more than 100 characters.");
                }
                else if (!main.CheckEmailFormat(email)) // check if email is valid
                {
                    txtInsertEmail.Focus();
                    throw new Exception("Invalid email format.");
                }
                else if (password == "") // check if password is blank
                {
                    pwdChoosePassword.Focus();
                    throw new Exception("Password cannot be empty");
                }
                else if (password.Length < 6) // check if password is too short
                {
                    pwdChoosePassword.Focus();
                    throw new Exception("Password needs to be at least 6 characters.");
                }
                else if (password.Length > 100) // check if password is too long
                {
                    pwdChoosePassword.Focus();
                    throw new Exception("Password cannot be more than 100 characters.");
                }
                else if (password != passwordVerified) // check if passwords are different
                {
                    pwdVerifyPassword.Focus();
                    throw new Exception("Passwords do not match.");
                }
                else
                {
                    if (_userManager.CreateNewAccount(username, email, password))
                    {
                        DataDomain.User user = _userManager.RetrieveUserByUsername(username);
                        main.UserChanged(null);
                        main.ShowMessage("Account Created", "Your account was created. Please log in again to continue.", "Default");
                    }
                    else
                    {
                        throw new Exception("There was an error creating the account.");
                    }
                }
            }
            catch(Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }


        }


















    }
}
