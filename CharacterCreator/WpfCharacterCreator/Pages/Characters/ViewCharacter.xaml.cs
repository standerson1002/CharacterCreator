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
    /// Interaction logic for ViewCharacter.xaml
    /// </summary>
    public partial class ViewCharacter : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();

        UserCharacter character;
        public ViewCharacter(UserCharacter character)
        {
            InitializeComponent();
            this.character = character;
            viewCharacter();
        }


        private void viewCharacter()
        {
            try
            {
                lblCreated.Content = "Created on " + character.CreatedAt.ToString("d") + " by " + character.CreatorID + "\tLast updated on " + character.LastEdited.ToString("d");

                // name
                lblCharacterNameProfile.Content = character.CharacterName;

                string fullName = "" + character.CharacterFirstName;
                if (character.CharacterMiddleName != null)
                {
                    fullName += " " + character.CharacterMiddleName;
                }
                if (character.CharacterLastName != null)
                {
                    fullName += " " + character.CharacterLastName;
                }
                lblCharacterFullName.Content = fullName;

                if (character.CreatorID == main.Username)
                {
                    btnShareCharacter.Visibility = Visibility.Visible;
                    btnShareCharacter.IsEnabled = true;
                    btnEditCharacter.Visibility = Visibility.Visible;
                }
                else
                {
                    btnShareCharacter.Visibility = Visibility.Hidden;
                    btnEditCharacter.Visibility = Visibility.Hidden;
                    lblCreator.Visibility = Visibility.Visible;
                    lblCreator.Content = "You do not have access to " + character.CharacterName + ".";
                    bool access = false;

                    List<UserPermission> sharedCharacters = _characterManager.GetAccessCharactersByUser(main.Username);
                    foreach (UserPermission permission in sharedCharacters)
                    {
                        if (permission.AccessType == "Editor" && permission.CharacterID == character.CharacterID)
                        {
                            btnEditCharacter.Visibility = Visibility.Visible;
                            lblCreator.Content = "You are an Editor for " + character.CreatorID + "'s Character.";
                            access = true;
                            break;
                        }
                        else if (permission.AccessType == "Viewer" && permission.CharacterID == character.CharacterID)
                        {
                            access = true;
                            lblCreator.Content = "You are a Viewer for " + character.CreatorID + "'s Character.";
                            break;
                        }
                    }
                    if (!access)
                    {
                        throw new Exception("Invalid access type for character.");
                    }
                }

                // traits
                List<CharacterTraitVM> characterTraits = _characterManager.GetAllTraitsForCharacter(character.CharacterID);
                if (characterTraits.Count == 0)
                {
                    lblTraits.Content = character.CharacterName + " has no traits.";
                    textTraits.Text = "";
                }
                else
                {
                    lblTraits.Content = character.CharacterName + " is...";
                    foreach (CharacterTraitVM trait in characterTraits)
                    {
                        textTraits.Text += trait.TraitID + ": " + trait.TraitDescription + "\n";
                    }
                }

                // skills
                List<CharacterSkill> characterSkills = _characterManager.GetAllSkillsForCharacter(character.CharacterID);
                if (characterSkills.Count == 0)
                {
                    lblSkills.Content = character.CharacterName + " has no skills.";
                    textSkills.Text = "";
                }
                else
                {
                    lblSkills.Content = character.CharacterName + " is skilled at...";
                    foreach (CharacterSkill skill in characterSkills)
                    {
                        textSkills.Text += skill.SkillID + ": " + skill.CharacterSkillDescription + "\n";
                    }
                }

                // interests
                List<CharacterLikeDislike> allInterests = _characterManager.GetAllInterestsForCharacter(character.CharacterID);
                List<CharacterLikeDislike> characterLikes = new List<CharacterLikeDislike>();
                List<CharacterLikeDislike> characterDislikes = new List<CharacterLikeDislike>();
                
                foreach (CharacterLikeDislike characterLikeDislike in allInterests)
                {
                    if (characterLikeDislike.LikeDislikeType == "Like")
                    {
                        characterLikes.Add(characterLikeDislike);
                    }
                    else
                    {
                        characterDislikes.Add(characterLikeDislike);
                    }
                }

                if (characterLikes.Count == 0)
                {
                    lblLikes.Content = character.CharacterName + " doesn't like anything.";
                    textLikes.Text = "";
                }
                else
                {
                    lblLikes.Content = character.CharacterName + " Likes...";
                    textLikes.Text = "";
                    foreach (CharacterLikeDislike like in characterLikes)
                    {
                        textLikes.Text += like.CharacterInterest + ": " + like.CharacterLikeDislikeDescription + "\n";
                    }
                }
                if (characterDislikes.Count == 0)
                {
                    lblDislikes.Content = character.CharacterName + " doesn't dislike anything.";
                    textDislikes.Text = "";
                }
                else
                {
                    lblDislikes.Content = character.CharacterName + " Dislikes...";
                    textDislikes.Text = "";
                    foreach (CharacterLikeDislike like in characterDislikes)
                    {
                        textDislikes.Text += like.CharacterInterest + ": " + like.CharacterLikeDislikeDescription + "\n";
                    }
                }

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Loading Character", ex.Message, "Error");
            }
        }


        private void btnEditCharacter_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            NavigationService.GetNavigationService(this).Navigate(new EditCharacter(character));
        }

        private void btnShareCharacter_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            NavigationService.GetNavigationService(this).Navigate(new CharacterPermissions(character));
        }
    }
}
