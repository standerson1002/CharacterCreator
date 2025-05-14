using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCharacterCreator.Pages;
using DataDomain;
using System.Windows.Navigation;
using WpfCharacterCreator.Pages.User;
using WpfCharacterCreator.Pages.Friends;
using WpfCharacterCreator.Pages.Characters;
using WpfCharacterCreator.Pages.Locations;

namespace WpfCharacterCreator
{
    /// <summary>
    /// Interaction logic for CharacterCreator.xaml
    /// </summary>
    public partial class CharacterCreator : Window
    {
        static CharacterCreator _this = null;
        private User _accessToken;
        public static CharacterCreator GetMainWindow()
        {
            return _this;
        }

        public CharacterCreator()
        {
            InitializeComponent();
            _this = this;

            UserChanged(null);
            ClearMessage();
        }

        public bool isLoggedIn { get { return _accessToken != null; } }

        public string Username
        {
            get { return _accessToken.Username; }
        }

        public string Email
        {
            get { return _accessToken.Email; }
        }

        // User Methods

        public void UserChanged(User user)
        {
            Visibility visibility = Visibility.Collapsed;

            if (user != null)
            {
                _accessToken = user;
                visibility = Visibility.Visible;
                mainFrame.Navigate(new ViewOwnProfile());
                ShowMessage("Welcome back, " + _accessToken.Username, "You are now logged in.", "Default");
            }
            else
            {
                _accessToken = null;
                visibility = Visibility.Hidden;
                mainFrame.Navigate(new Login());
                ShowMessage("Goodbye", "You are now logged out.", "Default");
            }

            btnFriends.Visibility = visibility;
            btnCharacters.Visibility = visibility;
            btnLocations.Visibility = visibility;

            btnLogout.Visibility = visibility;
            btnProfile.Visibility = visibility;

        }


        // Message Methods
        public void ClearMessage()
        {
            lblMessageTitle.Content = "";
            txtMessageDescription.Text = "";

            lblMessageTitle.Style = this.FindResource("MessageDefaultLabel") as Style;
            txtMessageDescription.Style = this.FindResource("MessageDefaultText") as Style;
            panelMessage.Style = this.FindResource("MessageBackground") as Style;
        }


        public void ShowMessage(string title, string message, string type)
        {
            ClearMessage();

            lblMessageTitle.Content = title;
            txtMessageDescription.Text = message;

            string labelStyle = "MessageDefaultLabel";
            string textStyle = "MessageDefaultText";
            string backgroundStyle = "MessageBackground";

            if(type == "Error")
            {
                labelStyle = "MessageErrorLabel";
                textStyle = "MessageErrorText";
                backgroundStyle = "MessageErrorBackground";
            }
            else if (type == "Success")
            {
                labelStyle = "MessageSuccessLabel";
                textStyle = "MessageSuccessText";
                backgroundStyle = "MessageSuccessBackground";
            }
            else if (type == "Default")
            {
                backgroundStyle = "MessageDefaultBackground";
            }

            lblMessageTitle.Style = this.FindResource(labelStyle) as Style;
            txtMessageDescription.Style = this.FindResource(textStyle) as Style;
            panelMessage.Style = this.FindResource(backgroundStyle) as Style;
        }



        // Helper Methods
        public bool CheckEmailFormat(string email)
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

        private void btnFriends_Click(object sender, RoutedEventArgs e)
        {
            ClearMessage();
            mainFrame.Navigate(new ViewFriendList());
        }

        private void btnCharacters_Click(object sender, RoutedEventArgs e)
        {
            ClearMessage();
            mainFrame.Navigate(new ViewCharacterList());
        }

        private void btnLocations_Click(object sender, RoutedEventArgs e)
        {
            ClearMessage();
            mainFrame.Navigate(new ViewLocationList());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                UserChanged(null);
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ViewOwnProfile());
        }
    }
}
