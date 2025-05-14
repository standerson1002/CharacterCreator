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
using WpfCharacterCreator.Pages.Friends;

namespace WpfCharacterCreator.Pages.User
{
    /// <summary>
    /// Interaction logic for ViewFriendProfile.xaml
    /// </summary>
    public partial class ViewFriendProfile : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager();

        DataDomain.User _otherUser = null;
        string user;


        public ViewFriendProfile(DataDomain.User otherUser)
        {
            InitializeComponent();
            _otherUser = otherUser;
            user = main.Username;
            determineRelationship();
        }

        private void determineRelationship()
        {

            lblOtherUserProfileUsername.Content = _otherUser.Username;
            lblOtherUserFriendStatus.Content = "";

            if (_otherUser.AccountBio != "")
            {
                txtOtherUserProfileBio.IsEnabled = true;
                txtOtherUserProfileBio.Text = _otherUser.AccountBio;
            }
            else
            {
                txtOtherUserProfileBio.IsEnabled = false;
                txtOtherUserProfileBio.Text = _otherUser.Username + " has not made a bio yet.";
            }

            btnOtherUserAcceptFriendRequest.Visibility = Visibility.Hidden;
            btnOtherUserRejectFriendRequest.Visibility= Visibility.Hidden;
            btnOtherUserCancelFriendRequest.Visibility = Visibility.Hidden;
            btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Hidden;
            btnOtherUserUnfriend.Visibility = Visibility.Hidden;

            try
            {
                UserFriend? friend = _userManager.RetrieveFriendStatus(user, _otherUser.Username);

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
                        lblOtherUserFriendStatus.Content = "You Have Sent a Friend Request to " + _otherUser.Username;
                        btnOtherUserCancelFriendRequest.Visibility = Visibility.Visible;
                    }
                    else if (friend.UserFriendStatus == "waiting")
                    {
                        lblOtherUserFriendStatus.Content = _otherUser.Username + " Has Sent You a Friend Request";
                        btnOtherUserAcceptFriendRequest.Visibility = Visibility.Visible;
                        btnOtherUserRejectFriendRequest.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (NullReferenceException)
            {
                btnOtherUserProfileSendFriendRequest.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Occured", ex.Message, "Error");
            }
        }


        private void btnOtherUserProfileBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewFriendList());
        }

        private void btnOtherUserProfileSendFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userManager.SendFriendRequest(user, _otherUser.Username))
                {
                    main.ShowMessage("Friend Request Sent", "A friend request was sent to " + _otherUser.Username, "Success");
                }
                else
                {
                    throw new Exception("Failed to send friend request.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Sending Friend Request", ex.Message, "Error");
            }

            determineRelationship();
        }
        private void btnOtherUserCancelFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userManager.CancelPendingFriendRequest(user, _otherUser.Username))
                {
                    main.ShowMessage("Friend Request Canceled", "Canceled friend request for " + _otherUser.Username, "Success");
                }
                else
                {
                    throw new Exception("Failed to cancel friend request.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Canceling Friend Request", ex.Message, "Error");
            }

            determineRelationship();
        }
        private void btnOtherUserUnfriend_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove " + _otherUser.Username + " as a friend?",
                                                      "Remove Friend", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (_userManager.RemoveFriend(user, _otherUser.Username))
                    {
                        main.ShowMessage("Friend Removed", "Removed " + _otherUser.Username + " as friend.", "Success");
                        NavigationService.GetNavigationService(this).Navigate(new ViewFriendProfile(_otherUser));
                    }
                    else
                    {
                        throw new Exception("Failed to remove friend.");
                    }
                }
                catch (Exception ex)
                {
                    main.ShowMessage("Error Unfriending Friend", ex.Message, "Error");
                }

                determineRelationship();
            }
        }
        private void btnOtherUserRejectFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userManager.RejectFriendRequest(user, _otherUser.Username))
                {
                    main.ShowMessage("Friend Request Rejected", "Rejected friend request for " + _otherUser.Username, "Success");
                }
                else
                {
                    throw new Exception("Failed to reject friend request.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Rejecting Friend Request", ex.Message, "Error");
            }

            determineRelationship();
        }
        private void btnOtherUserAcceptFriendRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userManager.AcceptFriendRequest(user, _otherUser.Username))
                {
                    main.ShowMessage("Friend Request Accepted", "Accepted friend request for " + _otherUser.Username, "Success");
                }
                else
                {
                    throw new Exception("Failed to accept friend request.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Accepting Friend Request", ex.Message, "Error");
            }

            determineRelationship();
        }




    }
}
