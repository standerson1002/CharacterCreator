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
    /// Interaction logic for CharacterPermissions.xaml
    /// </summary>
    public partial class CharacterPermissions : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();

        UserCharacter character;
        List<UserPermission> userPermissions = new List<UserPermission>();
        public CharacterPermissions(UserCharacter character)
        {
            InitializeComponent();
            this.character = character;
            try
            {
                userPermissions = _characterManager.GetAccessForCharacter(character.CharacterID);
                lblCharacterPermissions.Content = "Permissions for " + character.CharacterName + " (" + userPermissions.Count + ")";

                gridPermissions.ItemsSource = userPermissions;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ShareCharacter(character));
        }

        private void btnEditPermission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserPermission permission = (UserPermission)gridPermissions.SelectedItem;
                if (permission != null)
                {
                    NavigationService.GetNavigationService(this).Navigate(new EditCharacterPermission(permission));
                }
                else
                {
                    throw new Exception("Invalid permission selected.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }

        }

        private void btnViewCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewCharacter(character));
        }
    }
}
