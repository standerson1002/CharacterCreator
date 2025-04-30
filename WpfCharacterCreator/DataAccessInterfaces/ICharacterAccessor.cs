using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface ICharacterAccessor
    {
        List<UserCharacter> SelectCharacterList(string user);
        List<UserPermission> SelectAccessCharactersList(string user);
        bool InsertNewCharacter(UserCharacter character);
        bool DeactivateCharacter(string user, int characterID, string characterName);
        UserCharacter ViewCharacterByCharacterID(int characterID);
        bool GiveAccessForCharacter(string user, string creator, int character, string access);
        bool RemoveAccessForCharacter(string user, int character);

        List<UserPermission> ViewAccessForCharacter(int characterID); 


        bool UpdateCharacter(UserCharacter character, string newName,
            string newFirstName, string newMiddleName, string newLastName);

        // traits
        List<Trait> GetAllTraits();
        List<CharacterTraitVM> GetAllTraitsForCharacter(int characterID);
        bool AddTraitToCharacter(int characterID, string traitID);
        bool RemoveTraitFromCharacter(int characterID, string traitID);

        // skills
        public List<Skill> GetAllSkills();
        public List<CharacterSkill> GetAllSkillsForCharacter(int characterID);
        public bool AddSkillToCharacter(int characterID, string skillID, string description);
        public bool UpdateSkillForCharacter(int characterID, string skillID, string oldDescription, string newDescription);
        public bool RemoveSkillFromCharacter(int characterID, string skillID);

        // interests
        public List<CharacterLikeDislike> GetAllInterestsForCharacter(int characterID);
        public bool AddInterestToCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription);
        public bool RemoveInterestFromCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription);
        public bool UpdateInterestForCharacter(int characterID, string oldInterestID, string newInterestID, string oldInterestDescription, string newInterestDescription);

    }
}
