using Azure.Core;
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
using DataDomain;
using LogicLayer;
using WpfCharacterCreator.Pages.User;

namespace WpfCharacterCreator.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();

        UserManager _userManager = new UserManager();
        public Login()
        {
            InitializeComponent();
        }

        private void btnCreateNewAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Signup());
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsername.Text;
            string password = pwdPassword.Password;
            try
            {
                if (username == "") // check if username is blank
                {
                    txtUsername.Focus();
                    throw new Exception("Username cannot be empty.");
                }
                else if (password == "") // check if password is blank
                {
                    pwdPassword.Focus();
                    throw new Exception("Password cannot be empty.");
                }
                else
                {
                    DataDomain.User user = _userManager.LogInUser(username, password);
                    if(user == null)
                    {
                        throw new Exception("Bad username or password.");
                    }
                    else
                    {
                        main.UserChanged(user);
                    }
                }
            }
            catch(Exception ex)
            {
                main.ShowMessage("Login Failed", ex.Message, "Error");
            }
        }

        private void btnOriginalVersion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
