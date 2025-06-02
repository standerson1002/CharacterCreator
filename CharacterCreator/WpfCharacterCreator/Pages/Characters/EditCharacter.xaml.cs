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
    /// Interaction logic for EditCharacter.xaml
    /// </summary>
    public partial class EditCharacter : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        CharacterManager _characterManager = new CharacterManager();
        UserManager _userManager = new UserManager();

        UserCharacter character;

        List<Trait> availableTraits = new List<Trait>();
        List<CharacterTraitVM> characterTraits = new List<CharacterTraitVM>();
        List<Trait> traitCharacter = new List<Trait>();

        List<Skill> availableSkills = new List<Skill>();
        List<CharacterSkill> characterSkills = new List<CharacterSkill>();

        List<CharacterLikeDislike> allInterests = new List<CharacterLikeDislike>();
        List<CharacterLikeDislike> characterLikes = new List<CharacterLikeDislike>();
        List<CharacterLikeDislike> characterDislikes = new List<CharacterLikeDislike>();

        public EditCharacter(UserCharacter character)
        {
            InitializeComponent();
            this.character = character;

            populateInformation();
        }


        private void populateInformation()
        {
            try
            {
                lblCreated.Content = "Created on " + character.CreatedAt.ToString("D") + " by " + character.CreatorID + " | Last updated on " + character.LastEdited.ToString("D"); ;

                txtCharacterName.Text = character.CharacterName;
                txtFirstName.Text = character.CharacterFirstName;
                txtMiddleName.Text = character.CharacterMiddleName;
                txtLastName.Text = character.CharacterLastName;

                pwdDeactivateCharacter.Clear();

                if (main.Username != character.CreatorID)
                {
                    tabDeactivateCharacter.Visibility = Visibility.Hidden;
                }

                updateTraits();
                updateSkills();
                updateInterests();
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnUpdateIdentity_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            string newName = txtCharacterName.Text;
            if (newName == "" || newName == null)
            {
                newName = character.CharacterName;
            }
            string? newFirstName = (txtFirstName.Text == "" ? null : txtFirstName.Text);
            string? newMiddleName = (txtMiddleName.Text == "" ? null : txtMiddleName.Text);
            string? newLastName = (txtLastName.Text == "" ? null : txtLastName.Text);
            try
            {
                if (_characterManager.UpdateCharacter(character, newName, newFirstName, newMiddleName, newLastName))
                {
                    character = _characterManager.GetCharacterByCharacterID(character.CharacterID);
                    main.ShowMessage("Update Success", character.CharacterName + " was updated.", "Success");
                    NavigationService.GetNavigationService(this).Navigate(new ViewCharacter(character));
                }
                else
                {
                    throw new Exception("Character was not updated");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Character", ex.Message, "Error");
            }
        }
        private void btnCancelUpdateCharacter_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            MessageBoxResult result = MessageBox.Show("Are you sure you want to discard your changes?", "Discard Changes?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                main.ShowMessage("Changed Discarded", "Changes made to " + character.CharacterName + " were discarded.", "Warning");
                NavigationService.GetNavigationService(this).Navigate(new ViewCharacter(character));
            }
        }
        private void btnDeactivateCharacter_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();
            string password = pwdDeactivateCharacter.Password;

            try
            {
                if (_userManager.AuthenticateUser(main.Username, password))
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to deactivate this character.\nThis can NOT be undone!", "Deactive Character?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (_characterManager.DeactivateCharacter(main.Username, character.CharacterID, character.CharacterName))
                        {
                            main.ShowMessage("Character Deactivated", character.CharacterName + " was deactivated.", "Success");
                            NavigationService.GetNavigationService(this).Navigate(new ViewCharacterList());
                        }
                        else
                        {
                            throw new Exception("Character was not deactivated.");
                        }
                    }
                }
                else
                {
                    pwdDeactivateCharacter.Focus();
                    throw new Exception("Incorrect password used.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }

        }


        private void updateTraits()
        {
            try
            {
                List<Trait> allTraits = _characterManager.GetAllTraits();
                characterTraits = _characterManager.GetAllTraitsForCharacter(character.CharacterID);
                availableTraits = new List<Trait>();

                foreach (var trait in allTraits)
                {
                    bool available = true;
                    foreach (var charTrait in characterTraits)
                    {
                        if (charTrait.TraitID == trait.TraitID)
                        {
                            available = false;
                        }
                    }
                    if (available)
                    {
                        availableTraits.Add(trait);
                    }
                }

                listCharacterTraits.ItemsSource = availableTraits;
                listCharacterTraits.ItemsSource = characterTraits;

                listTraits.ItemsSource = characterTraits;
                listTraits.ItemsSource = availableTraits;

            }
            catch(Exception ex)
            {
                main.ShowMessage("Error Loading Traits", ex.Message, "Error");
            }
        }
        private void btnAddTrait_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                Trait trait = (Trait)listTraits.SelectedItem;

                if (_characterManager.AddTraitToCharacter(character.CharacterID, trait.TraitID))
                {
                    updateTraits();
                    main.ShowMessage("Trait Added", trait.TraitID + " aas added to " + character.CharacterName, "Success");
                }
                else
                {
                    throw new Exception("Trait was not added.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Adding Trait", ex.Message, "Error");
            }
        }
        private void btnRemoveTrait_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                CharacterTraitVM trait = (CharacterTraitVM)listCharacterTraits.SelectedItem;

                if (_characterManager.RemoveTraitFromCharacter(character.CharacterID, trait.TraitID))
                {
                    updateTraits();
                    main.ShowMessage("Trait Removed", trait.TraitID + " was removed from " + character.CharacterName, "Success");
                }
                else
                {
                    throw new Exception("Trait was not added.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Removing Trait", ex.Message, "Error");
            }
        }


        private void updateSkills()
        {
            try
            {
                characterSkills = _characterManager.GetAllSkillsForCharacter(character.CharacterID);

                List<Skill> allSkills = _characterManager.GetAllSkills();
                characterSkills = _characterManager.GetAllSkillsForCharacter(character.CharacterID);
                availableSkills = new List<Skill>();

                foreach (var skill in allSkills)
                {
                    bool available = true;
                    foreach (var charSkill in characterSkills)
                    {
                        if (charSkill.SkillID == skill.SkillID)
                        {
                            available = false;
                        }
                    }
                    if (available)
                    {
                        availableSkills.Add(skill);
                    }
                }
                listCharacterSkills.ItemsSource = characterSkills;
                listSkills.ItemsSource = availableSkills;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Skills", ex.Message, "Error");
            }
        }
        private void listCharacterSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CharacterSkill skill = (CharacterSkill)listCharacterSkills.SelectedItem;
                if (skill != null)
                {
                    textUpdateSkillDescription.Text = skill.CharacterSkillDescription;
                }
                else
                {
                    textUpdateSkillDescription.Clear();
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }
        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                Skill skill = (Skill)listSkills.SelectedItem;

                string skillDescription = textSkillDescription.Text.Trim();
                if (skillDescription == null)
                {
                    skillDescription = "";
                }

                if (_characterManager.AddSkillToCharacter(character.CharacterID, skill.SkillID, skillDescription))
                {
                    textSkillDescription.Clear();

                    updateSkills();
                    main.ShowMessage("Skill Added", skill.SkillID + " was added to " + character.CharacterName, "Success");
                }
                else
                {
                    throw new Exception("Skill was not added.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Adding Skill", ex.Message, "Error");
            }
        }
        private void btnRemoveSkill_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                CharacterSkill skill = (CharacterSkill)listCharacterSkills.SelectedItem;

                if (_characterManager.RemoveSkillFromCharacter(character.CharacterID, skill.SkillID))
                {
                    updateSkills();
                    textUpdateSkillDescription.Clear();
                    main.ShowMessage("Skill Added", skill.SkillID + " was removed from " + character.CharacterName, "Success");
                }
                else
                {
                    throw new Exception("Skill was not removed");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Removing Skill", ex.Message, "Error");
            }
        }
        private void btnUpdateSkill_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                CharacterSkill skill = (CharacterSkill)listCharacterSkills.SelectedItem;
                string oldDescription = skill.CharacterSkillDescription;
                string newDescription = textUpdateSkillDescription.Text.Trim();

                if (_characterManager.UpdateSkillForCharacter(character.CharacterID, skill.SkillID, oldDescription, newDescription))
                {
                    updateSkills();
                    textUpdateSkillDescription.Clear();
                    main.ShowMessage("Skill Updated", skill.SkillID + " for " + character.CharacterName + " was updated", "Success");
                }
                else
                {
                    throw new Exception("Skill not updated.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Skill", ex.Message, "Error");
            }
        }


        private void updateInterests()
        {
            textLikeDislike.Clear();
            textAddLikeDislikeDescription.Clear();
            textLikeDislikeDescription.Clear();

            characterLikes.Clear();
            characterDislikes.Clear();

            try
            {
                allInterests = _characterManager.GetAllInterestsForCharacter(character.CharacterID);
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

                listCharacterLikes.ItemsSource = characterDislikes;
                listCharacterDislikes.ItemsSource = characterLikes;

                listCharacterLikes.ItemsSource = characterLikes;
                listCharacterDislikes.ItemsSource = characterDislikes;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Likes and Dislikes", ex.Message, "Error");
            }
        }
        private void btnRemoveInterest_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                string interest = textLikeDislike.Text;
                string description = textLikeDislikeDescription.Text;

                string type = "Dislike";
                if (btnUpdateInterest.Content == "Update Like")
                {
                    type = "Like";
                }

                if (_characterManager.RemoveInterestFromCharacter(character.CharacterID, type, interest, description))
                {
                    updateInterests();
                    main.ShowMessage(type + " Updated", type + " was removed for " + character.CharacterName, "Success");
                }
                else
                {
                    throw new Exception(type + " was not removed.");
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Removing Like or Dislike", ex.Message, "Error");
            }
        }
        private void btnUpdateInterest_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                string type = "";

                string newInterest = textLikeDislike.Text;
                string newDescription = textLikeDislikeDescription.Text;

                string oldInterest = newInterest;
                string oldDescription = newDescription;

                if (btnUpdateInterest.Content == "Update Like")
                {
                    type = "Like";
                    oldInterest = characterLikes[listCharacterLikes.SelectedIndex].CharacterInterest;
                    oldDescription = characterLikes[listCharacterLikes.SelectedIndex].CharacterLikeDislikeDescription;
                }
                else if (btnUpdateInterest.Content == "Update Dislike")
                {
                    type = "Dislike";
                    oldInterest = characterDislikes[listCharacterDislikes.SelectedIndex].CharacterInterest;
                    oldDescription = characterDislikes[listCharacterDislikes.SelectedIndex].CharacterLikeDislikeDescription;
                }
                else
                {
                    throw new Exception("Invalid selection for like or dislike.");
                }

                if (newInterest == "")
                {
                    textLikeDislike.Focus();
                    throw new Exception(type + " cannot be empty.");
                }
                else if (newInterest.Length > 25)
                {
                    textLikeDislike.Focus();
                    throw new Exception(type + " cannot be more than 25 characters.");
                }
                else if (newDescription == "")
                {
                    textLikeDislikeDescription.Focus();
                    throw new Exception("Description cannot be empty");
                }
                else if (newDescription.Length > 50)
                {
                    textLikeDislikeDescription.Focus();
                    throw new Exception("Description cannot be more than 50 characters");
                }
                else
                {
                    if (_characterManager.UpdateInterestForCharacter(character.CharacterID, type, oldInterest, newInterest, oldDescription, newDescription))
                    {
                        updateInterests();
                        main.ShowMessage(type + " Updated", "The " + type + " was updated.", "Success");
                    }
                    else
                    {
                        throw new Exception(type + " not updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Like or Dislike", ex.Message, "Error");
            }
        }
        private void listCharacterDislikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                CharacterLikeDislike dislike = (CharacterLikeDislike)listCharacterDislikes.SelectedItem;

                if (dislike != null)
                {
                    textLikeDislike.Text = dislike.CharacterInterest;
                    textLikeDislikeDescription.Text = dislike.CharacterLikeDislikeDescription;

                    btnUpdateInterest.Content = "Update Dislike";
                    btnRemoveInterest.Content = "Remove Dislike";
                }

                listCharacterLikes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }
        private void listCharacterLikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                CharacterLikeDislike like = (CharacterLikeDislike)listCharacterLikes.SelectedItem;

                if (like != null)
                {
                    textLikeDislike.Text = like.CharacterInterest;
                    textLikeDislikeDescription.Text = like.CharacterLikeDislikeDescription;

                    btnUpdateInterest.Content = "Update Like";
                    btnRemoveInterest.Content = "Remove Like";
                }

                listCharacterDislikes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }
        private void btnAddLikeOrDislike_Click(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                string type = comboLikeDislike.Text;
                string interest = textLikeDislikeName.Text;
                string description = textAddLikeDislikeDescription.Text;

                foreach (CharacterLikeDislike value in allInterests)
                {
                    if (value.CharacterInterest == interest)
                    {
                        throw new Exception(character.CharacterName + " already " + value.LikeDislikeType + "s " + interest);
                    }
                }

                if (type != "Like" && type != "Dislike")
                {
                    comboLikeDislike.Focus();
                    throw new Exception("Invalid type selection.");
                }
                else if (interest == "" || interest == null)
                {
                    textLikeDislikeName.Focus();
                    throw new Exception(type + " cannot be empty.");
                }
                else if (interest.Length > 25)
                {
                    textLikeDislikeName.Focus();
                    throw new Exception(type + " cannot be more than 25 characters.");
                }
                else if (description == "")
                {
                    textLikeDislikeName.Focus();
                    throw new Exception("Description cannot be empty.");
                }
                else if (description.Length > 50)
                {
                    textLikeDislikeName.Focus();
                    throw new Exception("Description cannot be more than 50 characters.");
                }
                else
                {
                    if (_characterManager.AddInterestToCharacter(character.CharacterID, type, interest, description))
                    {
                        textLikeDislikeName.Clear();
                        updateInterests();
                        main.ShowMessage(type + " was Added", type + " was addded.", "Success");
                    }
                    else
                    {
                        throw new Exception(type + " was not added.");
                    }
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Adding Like or Dislike", ex.Message, "Error");
            }
        }

        private void comboLikeDislike_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboLikeDislike_Selected(sender, e);
        }

        private void comboLikeDislike_Selected(object sender, RoutedEventArgs e)
        {
            main.ClearMessage();

            try
            {
                string type = comboLikeDislike.SelectedIndex == 0 ? "Like" : "Dislike";

                if (type == "Like" || type == "Dislike")
                {
                    btnAddLikeOrDislike.Content = "Add " + type;
                }
                else
                {
                    throw new Exception("Invalid type: " + type);
                }

                comboLikeDislike.Text = type;
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Selecting Like or Dislike Type", ex.Message, "Error");
            }

        }
    }
}
