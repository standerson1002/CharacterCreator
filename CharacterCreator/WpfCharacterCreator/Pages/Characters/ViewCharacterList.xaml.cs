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

namespace WpfCharacterCreator.Pages.Characters
{
    /// <summary>
    /// Interaction logic for ViewCharacterList.xaml
    /// </summary>
    public partial class ViewCharacterList : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();

        List<UserCharacter> userCharacters = new List<UserCharacter>();
        List<UserPermission> sharedCharacters = new List<UserPermission>();


        public ViewCharacterList()
        {
            InitializeComponent();
            populateLists();
        }


        private void populateLists()
        {
            try
            {
                userCharacters = _characterManager.GetCharactersByUser(main.Username);
                sharedCharacters = _characterManager.GetAccessCharactersByUser(main.Username);

                tabMyCharacters.Header = "My Characters (" + userCharacters.Count + ")";
                tabCharactersSharedWithMe.Header = "Shared With Me (" + sharedCharacters.Count + ")";

                listCharacters.ItemsSource = userCharacters;
                listSharedCharacters.ItemsSource = sharedCharacters;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnViewCharacterProfile_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            int character = listCharacters.SelectedIndex;
            try
            {
                if (character == -1)
                {
                    throw new Exception("No character selected");
                }
                else
                {
                    UserCharacter _currentCharacter = _characterManager.GetCharacterByCharacterID(userCharacters[character].CharacterID);
                    NavigationService.GetNavigationService(this).Navigate(new ViewCharacter(_currentCharacter));
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid Character", ex.Message, "Error");
            }
        }
        private void btnViewSharedCharacterProfile_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            int character = listSharedCharacters.SelectedIndex;
            try
            {
                if (character == -1)
                {
                    throw new Exception("No character selected");
                }
                else
                {
                    UserCharacter _currentCharacter = _characterManager.GetCharacterByCharacterID(sharedCharacters[character].CharacterID);
                    NavigationService.GetNavigationService(this).Navigate(new ViewCharacter(_currentCharacter));
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid Character", ex.Message, "Error");
            }
        }

        private void btnCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new CreateCharacter());
        }
    }
}
