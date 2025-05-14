using Azure.Core;
using DataDomain;
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
using WpfCharacterCreator.Pages.User;

namespace WpfCharacterCreator.Pages.Friends
{
    /// <summary>
    /// Interaction logic for ViewFriendList.xaml
    /// </summary>
    public partial class ViewFriendList : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager();
        string username = null;

        List<UserFriend> userFriends = new List<UserFriend>();
        List<UserFriend> waitingRequests = new List<UserFriend>();
        List<UserFriend> pendingRequests = new List<UserFriend>();

        public ViewFriendList()
        {
            InitializeComponent();
            username = main.Username;

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

        private void btnViewFriendProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int friend = listFriends.SelectedIndex;
                string userFriend = userFriends[friend].UserFriendID;
                if (friend == null)
                {
                    throw new Exception("No user selected.");
                }
                else
                {
                    DataDomain.User user = _userManager.RetrieveUserByUsername(userFriend);
                    NavigationService.GetNavigationService(this).Navigate(new ViewFriendProfile(user));
                }

            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid User", ex.Message, "Error");
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
                    throw new Exception("No user selected.");
                }
                else
                {
                    DataDomain.User user = _userManager.RetrieveUserByUsername(userFriend);
                    NavigationService.GetNavigationService(this).Navigate(new ViewFriendProfile(user));
                }

            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid User", ex.Message, "Error");
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
                    throw new Exception("No user selected.");
                }
                else
                {
                    DataDomain.User user = _userManager.RetrieveUserByUsername(userFriend);
                    NavigationService.GetNavigationService(this).Navigate(new ViewFriendProfile(user));
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid User", ex.Message, "Error");
            }
        
        }

        private void btnSearchUsers_Click(object sender, RoutedEventArgs e)
        {
            
            string otherUsername = txtSearchUsers.Text;
            main.ClearMessage();

            if (otherUsername == username)
            {
                NavigationService.GetNavigationService(this).Navigate(new ViewOwnProfile());
            }
            else
            {
                try
                {
                    DataDomain.User otherUser = _userManager.RetrieveUserByUsername(otherUsername);
                    if (otherUser != null)
                    {
                        NavigationService.GetNavigationService(this).Navigate(new ViewFriendProfile(otherUser));
                    }
                    else
                    {
                        txtSearchUsers.Focus();
                        throw new Exception("No user found with the username: " + otherUsername);
                    }
                }
                catch (Exception ex)
                {
                    main.ShowMessage("User Not Found", ex.Message, "Error");
                }
            }
        }
    }
}
