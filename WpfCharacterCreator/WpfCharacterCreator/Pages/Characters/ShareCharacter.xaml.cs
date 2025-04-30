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

namespace WpfCharacterCreator.Pages.Characters
{
    /// <summary>
    /// Interaction logic for ShareCharacter.xaml
    /// </summary>
    public partial class ShareCharacter : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        UserManager _userManager = new UserManager();
        CharacterManager _characterManager = new CharacterManager();

        UserCharacter character;
        public ShareCharacter(UserCharacter character)
        {
            InitializeComponent();
            main.ClearMessage();

            this.character = character;
            populateInformation();
        }

        private void populateInformation()
        {
            try
            {
                List<string> availableFriends = new List<string>();
                List<UserFriend> friends = _userManager.RetrieveFriendList("user");
                List<UserPermission> permissions = _characterManager.GetAccessForCharacter(character.CharacterID);

                foreach (UserFriend friend in friends)
                {
                    bool available = true;

                    foreach (UserPermission permission in permissions)
                    {
                        if (friend.UserFriendID == permission.UserID)
                        {
                            available = false;
                        }
                    }
                    if (available)
                    {
                        availableFriends.Add(friend.UserFriendID);
                    }
                }

                comboFriendShare.ItemsSource = availableFriends;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnCancelShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
        }

        private void btnConfirmShareCharacter_Click(object sender, RoutedEventArgs e)
        {

            string friend = comboFriendShare.Text;
            string access = comboAccessType.Text;

            try
            {

                if (friend == "" || friend == null)
                {
                    comboFriendShare.Focus();
                    throw new Exception("Invalid friend.");
                }
                else if (access == "" || access == null)
                {
                    comboAccessType.Focus();
                    throw new Exception("Invalid access type.");
                }
                else
                {
                    List<UserPermission> permissions = _characterManager.GetAccessCharactersByUser(friend);
                    bool inUse = false;
                    foreach (UserPermission permission in permissions)
                    {
                        if (permission.CharacterID == character.CharacterID)
                        {
                            inUse = true;
                        }
                    }
                    if (!inUse)
                    {
                        if (_characterManager.GiveAccessToCharacter(friend, character.CreatorID, character.CharacterID, access))
                        {
                            main.ShowMessage("Character Shared", friend + " is now a " + access + " " + character.CharacterName + ".", "Success");
                            NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
                        }
                        else
                        {
                            throw new Exception("Character was not shared.");
                        }
                    }
                    else
                    {
                        throw new Exception(character.CharacterName + " has already been shared with " + friend);
                    }

                }

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Sharing Character", ex.Message, "Error");
            }
        }
    }
}
