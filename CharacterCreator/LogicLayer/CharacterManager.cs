using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CharacterManager : ICharacterManager
    {
        private ICharacterAccessor _characterAccessor;

        public CharacterManager()
        {
            _characterAccessor = new CharacterAccessor();

        }
        public CharacterManager(ICharacterAccessor characterAccessor)
        {
            _characterAccessor = characterAccessor;
        }

        public bool AddInterestToCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.AddInterestToCharacter(characterID, likeDislikeType, interestID, interestDescription);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool AddSkillToCharacter(int characterID, string skillID, string description)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.AddSkillToCharacter(characterID, skillID, description);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool AddTraitToCharacter(int characterID, string traitID)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.AddTraitToCharacter(characterID, traitID);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool CreateNewCharacter(UserCharacter character)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.InsertNewCharacter(character);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool DeactivateCharacter(string user, int characterID, string characterName)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.DeactivateCharacter(user, characterID, characterName);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public List<UserPermission> GetAccessCharactersByUser(string user)
        {
            List<UserPermission> characters = null;

            try
            {
                characters = _characterAccessor.SelectAccessCharactersList(user);
            }
            catch (Exception)
            {
                throw;
            }

            return characters;
        }

        public List<UserPermission> GetAccessForCharacter(int characterID)
        {
            List<UserPermission> userPermissions = null;

            try
            {
                userPermissions = _characterAccessor.ViewAccessForCharacter(characterID);
            }
            catch (Exception)
            {
                throw;
            }

            return userPermissions;
        }

        public List<CharacterLikeDislike> GetAllInterestsForCharacter(int characterID)
        {
            List<CharacterLikeDislike> interests = null;

            try
            {
                interests = _characterAccessor.GetAllInterestsForCharacter(characterID);
            }
            catch (Exception)
            {
                throw;
            }

            return interests;
        }

        public List<Skill> GetAllSkills()
        {
            List<Skill> skills = null;

            try
            {
                skills = _characterAccessor.GetAllSkills();
            }
            catch (Exception)
            {
                throw;
            }

            return skills;
        }

        public List<CharacterSkill> GetAllSkillsForCharacter(int characterID)
        {
            List<CharacterSkill> skills = null;

            try
            {
                skills = _characterAccessor.GetAllSkillsForCharacter(characterID);
            }
            catch (Exception)
            {
                throw;
            }

            return skills;
        }

        public List<Trait> GetAllTraits()
        {
            List<Trait> traits = null;

            try
            {
                traits = _characterAccessor.GetAllTraits();
            }
            catch (Exception)
            {
                throw;
            }

            return traits;
        }

        public List<CharacterTraitVM> GetAllTraitsForCharacter(int characterID)
        {
            List<CharacterTraitVM> characterTraits = null;

            try
            {
                characterTraits = _characterAccessor.GetAllTraitsForCharacter(characterID);
            }
            catch (Exception)
            {

                throw;
            }

            return characterTraits;
        }

        public UserCharacter GetCharacterByCharacterID(int characterID)
        {
            UserCharacter character = null;
            try
            {
                character = _characterAccessor.ViewCharacterByCharacterID(characterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return character;
        }

        public List<UserCharacter> GetCharactersByUser(string user)
        {
            List<UserCharacter> characters = null;

            try
            {
                characters = _characterAccessor.SelectCharacterList(user);
            }
            catch (Exception)
            {

                throw;
            }

            return characters;
        }

        public bool GiveAccessToCharacter(string user, string creator, int character, string access)
        {
            bool result = false;

            try
            {
                if (access == "Viewer" || access == "Editor")
                {
                    result = _characterAccessor.GiveAccessForCharacter(user, creator, character, access);
                }
                else if(access == "No Access")
                {
                    result = _characterAccessor.RemoveAccessForCharacter(user, character);
                }
                else
                {
                    throw new ArgumentException("Invalid Access Type");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool RemoveInterestFromCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.RemoveInterestFromCharacter(characterID, likeDislikeType, interestID, interestDescription);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool RemoveSkillFromCharacter(int characterID, string skillID)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.RemoveSkillFromCharacter(characterID, skillID);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool RemoveTraitFromCharacter(int characterID, string traitID)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.RemoveTraitFromCharacter(characterID, traitID);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateCharacter(UserCharacter character, string newName, string newFirstName, string newMiddleName, string newLastName)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.UpdateCharacter(character, newName, newFirstName, newMiddleName, newLastName);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateInterestForCharacter(int characterID, string likeDislikeType, string oldInterestID, string newInterestID, string oldInterestDescription, string newInterestDescription)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.UpdateInterestForCharacter(characterID, oldInterestID, newInterestID, oldInterestDescription, newInterestDescription);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public bool UpdateSkillForCharacter(int characterID, string skillID, string oldDescription, string newDescription)
        {
            bool result = false;

            try
            {
                result = _characterAccessor.UpdateSkillForCharacter(characterID, skillID, oldDescription, newDescription);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
