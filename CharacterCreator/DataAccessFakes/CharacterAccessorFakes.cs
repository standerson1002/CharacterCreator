using DataAccessInterfaces;
using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class CharacterAccessorFakes : ICharacterAccessor
    {
        private List<UserCharacter> _characters;
        private List<User> _users;
        private List<UserPermission> _permissions;
        private List<Trait> _traits;
        private List<CharacterTraitVM> _characterTraits;
        private List<Skill> _skills;
        private List<CharacterSkill> _characterSkills;
        private List<CharacterLikeDislike> _characterLikeDislikes;
        public CharacterAccessorFakes()
        {
            _characters = new List<UserCharacter>();
            _characters.Add(new UserCharacter()
            {
                CharacterID = 1,
                CreatorID = "test1",
                CharacterName = "Billy",
                CharacterFirstName = "William",
                CharacterLastName = "Jones",
                CharacterMiddleName = "",
                Active = false
            });
            _characters.Add(new UserCharacter()
            {
                CharacterID = 2,
                CreatorID = "test1",
                CharacterName = "Homer",
                CharacterFirstName = "Homer",
                CharacterLastName = "Simpson",
                CharacterMiddleName = "J",
                Active = true
            });
            _characters.Add(new UserCharacter()
            {
                CharacterID = 3,
                CreatorID = "test1",
                CharacterName = "Kim Kardashian",
                CharacterFirstName = "Kim",
                CharacterLastName = "Kardashian-West",
                CharacterMiddleName = "",
                Active = true
            });
            _characters.Add(new UserCharacter()
            {
                CharacterID = 4,
                CreatorID = "test1",
                CharacterName = "God",
                CharacterFirstName = "",
                CharacterLastName = "",
                CharacterMiddleName = "",
                Active = true
            });

            _users = new List<User>();
            _users.Add(new User()
            {
                Username = "test1",
                Email = "test1@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });
            _users.Add(new User()
            {
                Username = "test2",
                Email = "test2@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });
            _users.Add(new User()
            {
                Username = "test3",
                Email = "test3@test.com",
                AccountBio = "",
                PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true
            });

            _permissions = new List<UserPermission>();
            _permissions.Add(new UserPermission()
            {
                UserID = "test3",
                CharacterID = 2,
                AccessType = "Viewer"
            });

            _traits = new List<Trait>();
            _traits.Add(new Trait()
            {
                TraitID = "Smart",
                TraitConnotation = "positive",
                TraitDescription = "Having high intelligence."
            });
            _traits.Add(new Trait()
            {
                TraitID = "Average",
                TraitConnotation = "neutral",
                TraitDescription = "Being average."
            });
            _traits.Add(new Trait()
            {
                TraitID = "Dumb",
                TraitConnotation = "negative",
                TraitDescription = "Having low intelligence."
            });

            _characterTraits = new List<CharacterTraitVM>();
            _characterTraits.Add(new CharacterTraitVM()
            {
                CharacterID = 2,
                TraitID = "Dumb"
            });

            _skills = new List<Skill>();
            _skills.Add(new Skill()
            {
                SkillID = "Singing",
                SkillCategory = "Music",
                SkillDescription = "Using your voice to make song."
            });
            _skills.Add(new Skill()
            {
                SkillID = "Running",
                SkillCategory = "Athletic",
                SkillDescription = "Sprinting."
            });
            _skills.Add(new Skill()
            {
                SkillID = "Writing",
                SkillCategory = "Intelligent",
                SkillDescription = "Writing words on a computer or paper."
            });

            _characterSkills = new List<CharacterSkill>();
            _characterSkills.Add(new CharacterSkill()
            {
                CharacterID = 2,
                SkillID = "Singing",
                CharacterSkillDescription = "He's not actually good at singing, this is just an example."
            });

            _characterLikeDislikes = new List<CharacterLikeDislike>();
            _characterLikeDislikes.Add(new CharacterLikeDislike()
            {
                CharacterID = 2,
                LikeDislikeType = "Like",
                CharacterInterest = "Donuts",
                CharacterLikeDislikeDescription = "Donuts are his favorite food."
            });
            _characterLikeDislikes.Add(new CharacterLikeDislike()
            {
                CharacterID = 2,
                LikeDislikeType = "Like",
                CharacterInterest = "Beer",
                CharacterLikeDislikeDescription = "Beer are his favorite drink."
            });
            _characterLikeDislikes.Add(new CharacterLikeDislike()
            {
                CharacterID = 2,
                LikeDislikeType = "Dislike",
                CharacterInterest = "Running",
                CharacterLikeDislikeDescription = "Running is not fun for him."
            });
        }

        public bool AddInterestToCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            foreach(UserCharacter user in _characters)
            {
                if(user.CharacterID == characterID)
                {
                    result = true;
                }
            }

            if(result)
            {
                _characterLikeDislikes.Add(new CharacterLikeDislike()
                {
                    CharacterID = characterID,
                    LikeDislikeType = likeDislikeType,
                    CharacterInterest = interestID,
                    CharacterLikeDislikeDescription = interestDescription
                });
            }

            return result;

        }

        public bool AddSkillToCharacter(int characterID, string skillID, string description)
        {
            bool result = false;

            foreach (Skill skill in _skills)
            {
                if (skill.SkillID == skillID)
                {
                    foreach (UserCharacter character in _characters)
                    {
                        if (character.CharacterID == characterID)
                        {
                            _characterSkills.Add(new CharacterSkill()
                            {
                                CharacterID = characterID,
                                SkillID = skillID,
                                CharacterSkillDescription = description
                            });
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        public bool AddTraitToCharacter(int characterID, string traitID)
        {
            bool result = false;

            foreach(UserCharacter character in _characters)
            {
                if(character.CharacterID == characterID)
                {
                    foreach(Trait trait in _traits)
                    {
                        if(trait.TraitID == traitID)
                        {
                            _characterTraits.Add(new CharacterTraitVM()
                            {
                                CharacterID = characterID,
                                TraitID = traitID
                            });
                            result = true; break;
                        }
                    }
                }
            }

            return result;
        }

        public bool DeactivateCharacter(string user, int characterID, string characterName)
        {
            bool result = false;

            foreach(UserCharacter character in _characters)
            {
                if(character.CreatorID == user && character.CharacterID == characterID && character.CharacterName == characterName)
                {
                    character.Active = false;
                    result = true;
                }
            }

            return result;
        }

        public List<CharacterLikeDislike> GetAllInterestsForCharacter(int characterID)
        {
            List<CharacterLikeDislike> interests = new List<CharacterLikeDislike>();

            foreach(CharacterLikeDislike interest in _characterLikeDislikes)
            {
                if(interest.CharacterID == characterID)
                {
                    interests.Add(interest);
                }
            }

            return interests;
        }

        public List<Skill> GetAllSkills()
        {
            return _skills;
        }

        public List<CharacterSkill> GetAllSkillsForCharacter(int characterID)
        {
            List<CharacterSkill> skills = new List<CharacterSkill>();

            foreach(CharacterSkill characterSkill in _characterSkills)
            {
                if(characterSkill.CharacterID == characterID)
                {
                    skills.Add(characterSkill);
                }
            }

            return skills;
        }

        public List<Trait> GetAllTraits()
        {
            return _traits;
        }

        public List<CharacterTraitVM> GetAllTraitsForCharacter(int characterID)
        {
            List<CharacterTraitVM> characterTraits = new List<CharacterTraitVM>();

            foreach (CharacterTraitVM trait in _characterTraits)
            {
                if (trait.CharacterID == characterID)
                {
                    characterTraits.Add(trait);
                }
            }

            return characterTraits;
        }

        public bool GiveAccessForCharacter(string user, string creator, int character, string access)
        {
            return giveAccess(user, character, "Editor");
        }

        public bool InsertNewCharacter(UserCharacter character)
        {
            bool result = false;

            foreach(User user in _users)
            {
                if(character.CreatorID == user.Username && user.Active)
                {
                    result = true;
                }
            }

            if(result)
            {
                foreach (UserCharacter userCharacter in _characters)
                {
                    if (character.CharacterID == userCharacter.CharacterID)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                throw new ArgumentException("User not found.");
            }

            if(result)
            {
                _characters.Add(character);
            }
            else
            {
                throw new ArgumentException("CharacterID taken.");
            }

            return result;
        }

        public bool RemoveAccessForCharacter(string user, int character)
        {
            return giveAccess(user, character, "No Access");
        }

        public bool RemoveInterestFromCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            foreach(CharacterLikeDislike interest  in _characterLikeDislikes)
            {
                if(interest.CharacterID == characterID && interest.LikeDislikeType == likeDislikeType && interest.CharacterInterest == interestID && interest.CharacterLikeDislikeDescription == interestDescription)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool RemoveSkillFromCharacter(int characterID, string skillID)
        {
            bool result = false;

            foreach(CharacterSkill characterSkill in _characterSkills)
            {
                if( characterSkill.CharacterID == characterID && characterSkill.SkillID == skillID)
                {
                    // _characterSkills.Remove(characterSkill);
                    result = true;
                }
            }

            return result;
        }

        public bool RemoveTraitFromCharacter(int characterID, string traitID)
        {
            bool result = false;

            foreach (CharacterTrait characterTrait in _characterTraits)
            {
                if (characterTrait.CharacterID == characterID && characterTrait.TraitID == traitID)
                {
                    // _characterTraits.Remove(characterTrait);
                    result = true;
                }
            }

            return result;
        }

        public List<UserPermission> SelectAccessCharactersList(string user)
        {
            List<UserPermission> list = new List<UserPermission>();

            foreach(UserPermission permission in _permissions)
            {
                if(permission.UserID == user)
                {
                    list.Add(permission);
                }
            }
            return list;
        }

        public List<UserCharacter> SelectCharacterList(string user)
        {
            List<UserCharacter> characters = new List<UserCharacter>();

            try
            {
                foreach(UserCharacter userCharacter in _characters)
                {
                    if(userCharacter.CreatorID == user && userCharacter.Active)
                    {
                        characters.Add(userCharacter);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return characters;
        }


        public bool UpdateCharacter(UserCharacter character, string newName, string newFirstName, string newMiddleName, string newLastName)
        {
            bool result = false;
            foreach(UserCharacter userCharacter in _characters)
            {
                if(userCharacter.CharacterID == character.CharacterID)
                {
                    userCharacter.CharacterName = newName;
                    userCharacter.CharacterFirstName = newFirstName;
                    userCharacter.CharacterMiddleName = newMiddleName;
                    userCharacter.CharacterLastName = newLastName;
                    result = true;
                }
            }

            return result;
        }

        public bool UpdateInterestForCharacter(int characterID, string oldInterestID, string newInterestID, string oldInterestDescription, string newInterestDescription)
        {
            bool result = false;

            foreach(CharacterLikeDislike interest in _characterLikeDislikes)
            {
                if(interest.CharacterID == characterID && interest.CharacterInterest == oldInterestID && interest.CharacterLikeDislikeDescription == oldInterestDescription)
                {
                    interest.CharacterInterest = newInterestID;
                    interest.CharacterLikeDislikeDescription = newInterestDescription;
                    result = true;
                }
            }

            return result;
        }

        public bool UpdateSkillForCharacter(int characterID, string skillID, string oldDescription, string newDescription)
        {
            bool result = false;

            foreach (CharacterSkill characterSkill in _characterSkills)
            {
                if (characterSkill.CharacterID == characterID && characterSkill.SkillID == skillID && characterSkill.CharacterSkillDescription == oldDescription)
                {
                    characterSkill.CharacterSkillDescription = newDescription;
                    result = true;
                }
            }
            return result;
        }

        public List<UserPermission> ViewAccessForCharacter(int characterID)
        {
            List<UserPermission> userPermissions = new List<UserPermission>();
            foreach(UserPermission permission in _permissions)
            {
                if(permission.CharacterID == characterID)
                {
                    userPermissions.Add(permission);
                }
            }
            return userPermissions;
        }

        public UserCharacter ViewCharacterByCharacterID(int characterID)
        {
            UserCharacter character = null;
            foreach(UserCharacter characterCharacter in _characters)
            {
                if(characterCharacter.CharacterID == characterID && characterCharacter.Active == true)
                {
                    character = characterCharacter;
                }
            }
            return character;
        }


        /*
            Helper Methods
        */
        private bool giveAccess(string user, int character, string access)
        {
            bool result = false;
            
            foreach (UserPermission permission in _permissions)
            {
                if (permission.UserID == user && permission.CharacterID == character)
                {
                    permission.AccessType = access;
                    result = true;
                }
            }
            
            if(result == false)
            {
                foreach (UserCharacter userCharacter in _characters)
                {
                    if(userCharacter.CharacterID == character && userCharacter.CreatorID == user)
                    {
                        throw new ArgumentException("Cannot Edit Access for Creator");
                    }
                }

                int count = 0;

                foreach(UserCharacter userCharacter in _characters)
                {
                    if(userCharacter.CharacterID == character)
                    {
                        count++;
                    }

                }
                if(count != 1)
                {
                    throw new ArgumentException("Invalid Character", count + " characters");
                }

                count = 0;

                foreach (User userName in _users)
                {
                    if (userName.Username == user)
                    {
                        count++;
                    }
                }

                if (count != 1)
                {
                    throw new ArgumentException("Invalid User");
                }

                _permissions.Add(new UserPermission()
                {
                    UserID = user,
                    CharacterID = character,
                    AccessType = access
                });

                foreach (var permission in _permissions)
                {
                    if (permission.UserID == user && permission.CharacterID == character && permission.AccessType == access)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
