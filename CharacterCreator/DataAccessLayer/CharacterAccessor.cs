using DataAccessInterfaces;
using DataDomain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CharacterAccessor : ICharacterAccessor
    {
        public bool GiveAccessForCharacter(string user, string creator, int character, string access)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_give_access_for_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@AccessType", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@CreatorID"].Value = creator;
            cmd.Parameters["@CharacterID"].Value = character;
            cmd.Parameters["@AccessType"].Value = access;

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                result = rows == 1 || rows == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        public bool GiveViewAccessForCharacter(string user, int character)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_give_view_access_for_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@CharacterID"].Value = character;

            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                result = rows == 1 || rows == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        public bool RemoveAccessForCharacter(string user, int character)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_access_for_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@CharacterID"].Value = character;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<UserPermission> ViewAccessForCharacter(int characterID)
        {
            List<UserPermission> userPermissions = new List<UserPermission>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_access_for_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@CharacterID"].Value = characterID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userPermissions.Add(new UserPermission()
                    {
                        UserID = reader.GetString(0),
                        AccessType = reader.GetString(1),
                        CharacterID = characterID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return userPermissions;

        }


        public bool InsertNewCharacter(UserCharacter character)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_create_new_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CharacterName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@UserID"].Value = character.CreatorID;
            cmd.Parameters["@CharacterName"].Value = character.CharacterName;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<UserCharacter> SelectCharacterList(string user)
        {
            List<UserCharacter> characters = new List<UserCharacter>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_character_list", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    characters.Add(new UserCharacter()
                    {
                        CharacterID = reader.GetInt32(0),
                        CreatorID = user,
                        CharacterName = reader.GetString(1),
                        CharacterFirstName = reader.IsDBNull(2) ? null : reader.GetString(2),
                        CharacterLastName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CharacterMiddleName = reader.IsDBNull(4) ? null : reader.GetString(4),
                        CreatedAt = reader.GetDateTime(5),
                        LastEdited = reader.GetDateTime(6),
                        Active = true
                    });
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return characters;
        }

        public UserCharacter ViewCharacterByCharacterID(int characterID)
        {
            UserCharacter userCharacter = new UserCharacter();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_character_by_characterid", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@CharacterID"].Value = characterID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    userCharacter.CharacterID = characterID;
                    userCharacter.CreatorID = reader.GetString(0);
                    userCharacter.CharacterName = reader.GetString(1);
                    userCharacter.CharacterFirstName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    userCharacter.CharacterLastName = reader.IsDBNull(3) ? null : reader.GetString(3);
                    userCharacter.CharacterMiddleName = reader.IsDBNull(4) ? null : reader.GetString(4);
                    userCharacter.CreatedAt = reader.GetDateTime(5);
                    userCharacter.LastEdited = reader.GetDateTime(6);
                }
                else
                {
                    throw new Exception("Character Not Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return userCharacter;
        }

        public bool DeactivateCharacter(string user, int characterID, string characterName)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@CharacterName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@UserID"].Value = user;
            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@CharacterName"].Value = characterName;

            try
            {
                conn.Open();
                int number = cmd.ExecuteNonQuery();
                if(number == 0)
                {
                    throw new ArgumentException("None");
                }
                if(number == 1)
                {
                    result = true;
                }
                else
                {
                    throw new ArgumentException("Too Many");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        } 

        public List<UserPermission> SelectAccessCharactersList(string user)
        {
            List<UserPermission> characters = new List<UserPermission>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_access_characters", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@UserID"].Value = user;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    characters.Add(new UserPermission()
                    {
                        UserID = user,
                        CharacterID = reader.GetInt32(0),
                        CreatorID = reader.GetString(1),
                        CharacterName = reader.GetString(2),
                        AccessType = reader.GetString(3)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
                return characters;
            }

        public bool UpdateCharacter(UserCharacter character, string newName, string newFirstName, string newMiddleName, string newLastName)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_user_character", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@OldCharacterName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewCharacterName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldFirstName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewFirstName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldLastName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewLastName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldMiddleName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewMiddleName", SqlDbType.NVarChar, 50);

            cmd.Parameters["@CharacterID"].Value = character.CharacterID;
            cmd.Parameters["@OldCharacterName"].Value = character.CharacterName;
            cmd.Parameters["@NewCharacterName"].Value = newName;

            cmd.Parameters["@OldFirstName"].Value = character.CharacterFirstName;
            cmd.Parameters["@NewFirstName"].Value = newFirstName;
            cmd.Parameters["@OldLastName"].Value = character.CharacterLastName;
            cmd.Parameters["@NewLastName"].Value = newLastName;
            cmd.Parameters["@OldMiddleName"].Value = character.CharacterMiddleName;
            cmd.Parameters["@NewMiddleName"].Value = newMiddleName;

            // Code Source: https://stackoverflow.com/questions/4555935/assign-null-to-a-sqlparameter
            foreach (SqlParameter parameter in cmd.Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }
            
            try
            {
                conn.Open();
                int num = cmd.ExecuteNonQuery();
                if (num == 2 || num == 1)
                {
                    result = true;
                }
                else
                {
                    throw new Exception(num + " Characters Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        // traits
        public List<Trait> GetAllTraits()
        {
            List<Trait> traits = new List<Trait>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_traits", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    traits.Add(new Trait()
                    {
                        TraitID = reader.GetString(0),
                        TraitConnotation = reader.GetString(1),
                        TraitDescription = reader.GetString(2)
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return traits;
        }

        public List<CharacterTraitVM> GetAllTraitsForCharacter(int characterID)
        {
            List<CharacterTraitVM> characterTraits = new List<CharacterTraitVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_character_traits", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@CharacterID"].Value = characterID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    characterTraits.Add(new CharacterTraitVM()
                    {
                        CharacterID = characterID,
                        TraitDescription = reader.GetString(1),
                        TraitConnotation = reader.GetString(2),
                        TraitID = reader.GetString(3)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return characterTraits;
        }

        public bool AddTraitToCharacter(int characterID, string traitID)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_character_trait", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@TraitID", SqlDbType.NVarChar, 25);
            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@TraitID"].Value = traitID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool RemoveTraitFromCharacter(int characterID, string traitID)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_character_trait", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@TraitID", SqlDbType.NVarChar, 25);
            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@TraitID"].Value = traitID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        // skills
        public List<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_skill_types", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    skills.Add(new Skill()
                    {
                        SkillID = reader.GetString(0),
                        SkillCategory = reader.GetString(1)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return skills;
        }

        public List<CharacterSkill> GetAllSkillsForCharacter(int characterID)
        {
            List<CharacterSkill> skills = new List<CharacterSkill>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_character_skills", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@CharacterID"].Value = characterID;


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    skills.Add(new CharacterSkill()
                    {
                        CharacterID = characterID,
                        SkillID = reader.GetString(1),
                        CharacterSkillDescription = reader.GetString(2)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return skills;
        }

        public bool AddSkillToCharacter(int characterID, string skillID, string description)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_character_skill", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@SkillID", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@CharacterSkillDescription", SqlDbType.NVarChar, 100);
            
            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@SkillID"].Value = skillID;
            cmd.Parameters["@CharacterSkillDescription"].Value = description;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
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

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_character_skill", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@SkillID", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@OldCharacterSkillDescription", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewCharacterSkillDescription", SqlDbType.NVarChar, 100);

            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@SkillID"].Value = skillID;
            cmd.Parameters["@OldCharacterSkillDescription"].Value = oldDescription;
            cmd.Parameters["@NewCharacterSkillDescription"].Value = newDescription;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
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

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_character_skill", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@SkillID", SqlDbType.NVarChar, 25);
            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@SkillID"].Value = skillID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        // interests
        public List<CharacterLikeDislike> GetAllInterestsForCharacter(int characterID)
        {
            List<CharacterLikeDislike> interests = new List<CharacterLikeDislike>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_character_likes_and_dislikes", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters["@CharacterID"].Value = characterID;


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    interests.Add(new CharacterLikeDislike()
                    {
                        CharacterID = characterID,
                        LikeDislikeType = reader.GetString(0),
                        CharacterInterest = reader.GetString(1),
                        CharacterLikeDislikeDescription = reader.GetString(2)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return interests;
        }

        public bool AddInterestToCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_character_like_or_dislike", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@LikeDislikeType", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@CharacterLikeDislike", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@CharacterLikeDislikeDescription", SqlDbType.NVarChar, 50);

            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@LikeDislikeType"].Value = likeDislikeType;
            cmd.Parameters["@CharacterLikeDislike"].Value = interestID;
            cmd.Parameters["@CharacterLikeDislikeDescription"].Value = interestDescription;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool RemoveInterestFromCharacter(int characterID, string likeDislikeType, string interestID, string interestDescription)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_character_like_or_dislike", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@LikeDislikeType", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@CharacterLikeDislike", SqlDbType.NVarChar, 25);

            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@LikeDislikeType"].Value = likeDislikeType;
            cmd.Parameters["@CharacterLikeDislike"].Value = interestID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool UpdateInterestForCharacter(int characterID, string oldInterestID, string newInterestID, string oldInterestDescription, string newInterestDescription)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_character_like_or_dislike", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CharacterID", SqlDbType.Int);
            cmd.Parameters.Add("@OldCharacterLikeDislike", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@NewCharacterLikeDislike", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@OldCharacterLikeDislikeDescription", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewCharacterLikeDislikeDescription", SqlDbType.NVarChar, 50);

            cmd.Parameters["@CharacterID"].Value = characterID;
            cmd.Parameters["@OldCharacterLikeDislike"].Value = oldInterestID;
            cmd.Parameters["@NewCharacterLikeDislike"].Value = newInterestID;
            cmd.Parameters["@OldCharacterLikeDislikeDescription"].Value = oldInterestDescription;
            cmd.Parameters["@NewCharacterLikeDislikeDescription"].Value = newInterestDescription;
           
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

       
    }


}

