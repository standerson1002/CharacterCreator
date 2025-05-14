using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ICharacterManager
    {
        public List<UserCharacter> GetCharactersByUser(string user);
        public List<UserPermission> GetAccessCharactersByUser(string user);
        bool CreateNewCharacter(UserCharacter character);
        bool DeactivateCharacter(string user, int characterID,  string characterName);
        UserCharacter GetCharacterByCharacterID(int characterID);
        bool GiveAccessToCharacter(string user, string creator, int character, string access);

        public List<UserPermission> GetAccessForCharacter(int characterID);

        public bool UpdateCharacter(UserCharacter character, string newName, string newFirstName, string newMiddleName, string newLastName);


        // traits
        public List<Trait> GetAllTraits();
        public List<CharacterTraitVM> GetAllTraitsForCharacter(int characterID);
        public bool AddTraitToCharacter(int characterID, string traitID);
        public bool RemoveTraitFromCharacter(int characterID, string traitID);

        // skills
        public List<Skill> GetAllSkills();
        public List<CharacterSkill> GetAllSkillsForCharacter(int characterID);
        public bool AddSkillToCharacter(int characterID, string skillID, string description);
        public bool UpdateSkillForCharacter(int characterID, string skillID, string oldDescription, string newDescription);
        public bool RemoveSkillFromCharacter(int characterID, string skillID);

        // interests
        public List<CharacterLikeDislike> GetAllInterestsForCharacter(int characterID);
        public bool AddInterestToCharacter(int characterID, string likeDislikeType,string interestID, string interestDescription);
        public bool RemoveInterestFromCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription);
        public bool UpdateInterestForCharacter(int characterID, string likeDislikeType, string oldInterestID, string newInterestID, string oldInterestDescription, string newInterestDescription);

    }
}
