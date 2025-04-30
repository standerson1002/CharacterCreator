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
    /// Interaction logic for EditCharacterPermission.xaml
    /// </summary>
    public partial class EditCharacterPermission : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();

        UserPermission permission;
        UserCharacter character;

        public EditCharacterPermission(UserPermission permission)
        {
            InitializeComponent();
            this.permission = permission;
            populateInformation();
        }

        private void populateInformation()
        {
            try
            {
                character = _characterManager.GetCharacterByCharacterID(permission.CharacterID);
                txtUser.Text = permission.UserID;

                comboAccessTypes.Text = permission.AccessType;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string? access = comboAccessTypes.Text;
                if(access != null && access != "")
                {
                    bool result = _characterManager.GiveAccessToCharacter(permission.UserID, character.CreatorID, permission.CharacterID, access);
                    if (result)
                    {
                        main.ShowMessage("Permission Updated", "Updated permission for " + permission.UserID, "Success");
                        NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
                    }
                    else
                    {
                        throw new Exception("Access not updated." + result);
                    }
                }
                else
                {
                    throw new Exception("Invalid access type.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Permission", ex.Message, "Error");
            }
        }

        private void btnRemovePermission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_characterManager.GiveAccessToCharacter(permission.UserID, character.CreatorID, permission.CharacterID, "No Access"))
                {
                    main.ShowMessage("Permission Removed", "Removed permission for " + permission.UserID, "Success");
                    NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
                }
                else
                {
                    throw new Exception("Permission not removed.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Removing Permission", ex.Message, "Error");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
        }
    }
}
