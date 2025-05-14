using Azure.Core;
using DataDomain;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();

        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void btnCancelCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewCharacterList());
        }
        private void btnCreateCreateNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            string name = txtPickNameForNewCharacter.Text;
            try
            {
                if (name == "" || name == null) // check if name is empty
                {
                    throw new Exception("Character name cannot be empty.");
                }
                else if (name.Length > 50) // check if name is too long
                {
                    throw new Exception("Character name cannot be more than 50 characters long.");
                }
                else
                {
                    UserCharacter newCharacter = new UserCharacter()
                    {
                        CreatorID = main.Username,
                        CharacterName = name
                    };
                    if (_characterManager.CreateNewCharacter(newCharacter))
                    {
                        main.ShowMessage("Character Created", "Successfully made character: " + name, "Success");
                        NavigationService.GetNavigationService(this).Navigate(new ViewCharacterList());
                    }
                    else
                    {
                        throw new Exception("Character was not made.");
                    }
                }
            }
            catch(Exception ex)
            {
                main.ShowMessage("Error Creating Character", ex.Message, "Error");
            }
        }
    }
}
