using DataAccessFakes;
using DataDomain;
using LogicLayer;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass]
    public class CharacterManagerTests
    {
        private ICharacterManager? _characterManager;

        [TestInitialize]
        public void TestSetup()
        {
            _characterManager = new CharacterManager(new CharacterAccessorFakes());
        }



        // character list
        [TestMethod]
        public void TestSelectCharacterListByUserIsSuccessful()
        {
            // arrange
            string user = "test1";
            List<UserCharacter> characters = null;
            int expectedCharacterCount = 3;
            int actualCharacterCount = 0;

            // act
            characters = _characterManager.GetCharactersByUser(user);
            actualCharacterCount = characters.Count;

            // assert
            Assert.AreEqual(expectedCharacterCount, actualCharacterCount);

        }

        [TestMethod]
        public void TestSelectCharacterListReturnsNothingForNoUser()
        {
            // arrange
            string user = "test";
            List<UserCharacter> characters = null;
            int expectedCharacterCount = 0;
            int actualCharacterCount = 99;

            // act
            characters = _characterManager.GetCharactersByUser(user);
            actualCharacterCount = characters.Count;

            // assert
            Assert.AreEqual(expectedCharacterCount, actualCharacterCount);

        }


        // insert character
        [TestMethod]
        public void TestInsertNewCharacterReturnsTrueForSuccess()
        {
            // arrange
            UserCharacter character = new UserCharacter()
            {
                CharacterID = 9,
                CreatorID = "test1",
                CharacterName = "Tester",
                CharacterFirstName = "Test",
                CharacterLastName = "Test",
                CharacterMiddleName = "",
                Active = true
            };
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.CreateNewCharacter(character);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestInsertNewCharacterThrowsErrorForInvalidCreator()
        {
            // arrange
            UserCharacter character = new UserCharacter()
            {
                CharacterID = 9,
                CreatorID = "test",
                CharacterName = "Tester",
                CharacterFirstName = "Test",
                CharacterLastName = "Test",
                CharacterMiddleName = "",
                Active = true
            };

            // act
            _characterManager.CreateNewCharacter(character);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestInsertNewCharacterThrowsErrorForUsedCharacterID()
        {
            // arrange
            UserCharacter character = new UserCharacter()
            {
                CharacterID = 1,
                CreatorID = "test1",
                CharacterName = "Tester",
                CharacterFirstName = "Test",
                CharacterLastName = "Test",
                CharacterMiddleName = "",
                Active = true
            };

            // act
            _characterManager.CreateNewCharacter(character);

            // assert: nothing to do
        }


        // view character by character id
        [TestMethod]
        public void TestViewCharacterByCharacterIDIsSuccessful()
        {
            // arrange
            UserCharacter userCharacter;
            int characterID = 2;
            string expectedCreatorID = "test1";
            string actualCreatorID = "";
            string expectedCharacterName = "Homer";
            string actualCharacterName = "";

            // act
            userCharacter = _characterManager.GetCharacterByCharacterID(characterID);
            actualCreatorID = userCharacter.CreatorID;
            actualCharacterName = userCharacter.CharacterName;

            // assert
            Assert.AreEqual(expectedCreatorID, actualCreatorID);
            Assert.AreEqual(expectedCharacterName, actualCharacterName);

        }

        [TestMethod][ExpectedException(typeof(NullReferenceException))]
        public void TestViewCharacterByCharacterIDFailsForInactiveCharacter()
        {
            // arrange
            UserCharacter userCharacter;
            int characterID = 1;
            string expectedCreatorID = "test1";
            string actualCreatorID = "";

            // act
            userCharacter = _characterManager.GetCharacterByCharacterID(characterID);
            actualCreatorID = userCharacter.CreatorID;

            // assert
            Assert.AreEqual(expectedCreatorID, actualCreatorID);

        }

        [TestMethod][ExpectedException(typeof(NullReferenceException))]
        public void TestViewCharacterByCharacterIDFailsForInvalidCharacterID()
        {
            // arrange
            UserCharacter userCharacter;
            int characterID = 100;
            string expectedCreatorID = "test1";
            string actualCreatorID = "";

            // act
            userCharacter = _characterManager.GetCharacterByCharacterID(characterID);
            actualCreatorID = userCharacter.CreatorID;

            // assert
            Assert.AreEqual(expectedCreatorID, actualCreatorID);

        }


        // give character access
        [TestMethod]
        public void TestGiveViewAccessToCharacterReturnsTrueForSuccess()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test2";
            int characterID = 2;
            string access = "Viewer";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveViewAccessToCharacterThrowsErrorForInvalidUser()
        {
            // arrange
            string userID = "test";
            string creatorID = "test2";
            int characterID = 2;
            string access = "Viewer";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveViewAccessThrowsErrorForInvalidCharacter()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test";
            int characterID = 100;
            string access = "Viewer";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveViewAccessToCharacterThrowsErrorForCreator()
        {
            // arrange
            string userID = "test1";
            string creatorID = "test2";
            int characterID = 2;
            string access = "Viewer";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do

        }

        [TestMethod]
        public void TestGiveEditAccessToCharacterReturnsTrueForSuccess()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test1";
            int characterID = 2;
            string access = "Editor";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveEditAccessToCharacterThrowsErrorForInvalidUser()
        {
            // arrange
            string userID = "test";
            string creatorID = "test2";
            int characterID = 2;
            string access = "Editor";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveEditAccessThrowsErrorForInvalidCharacter()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test1";
            int characterID = 100;
            string access = "Editor";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveEditAccessToCharacterThrowsErrorForCreator()
        {
            // arrange
            string userID = "test1";
            string creatorID = "test2";
            int characterID = 2;
            string access = "Editor";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod]
        public void TestRemoveAccessToCharacterReturnsTrueForSuccess()
        {
            // arrange
            string userID = "test3";
            string creatorID = "test2";
            int characterID = 2;
            string access = "No Access";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestRemoveAccessToCharacterThrowsErrorForInvalidUser()
        {
            // arrange
            string userID = "test";
            string creatorID = "test2";
            int characterID = 2;
            string access = "No Access";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestRemoveAccessToCharacterThrowsErrorForInvalidCharacter()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test2";
            int characterID = 100;
            string access = "No Access";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestRemoveAccessToCharacterThrowsErrorForCreator()
        {
            // arrange
            string userID = "test1";
            string creatorID = "test2";
            int characterID = 2;
            string access = "No Access";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do
        }

        [TestMethod][ExpectedException(typeof(ArgumentException))]
        public void TestGiveAccessToCharacterThrowsErrorForInvalidAccessType()
        {
            // arrange
            string userID = "test2";
            string creatorID = "test2";
            int characterID = 1;
            string access = "";

            // act
            _characterManager.GiveAccessToCharacter(userID, creatorID, characterID, access);

            // assert: nothing to do

        }

        [TestMethod]
        public void TestViewAccessCharactersIsSuccessful()
        {
            // arrange
            string user = "test3";
            List<UserPermission> characters = null;
            int expectedResult = 1;
            int actualResult = 0;

            // act
            characters = _characterManager.GetAccessCharactersByUser(user);
            actualResult = characters.Count;

            // act
            Assert.AreEqual(expectedResult, actualResult);

        }

        // update character
        [TestMethod]
        public void TestUpdateCharacterReturnsTrueForSuccess()
        {
            // arrange
            int characterID = 2;
            UserCharacter userCharacter = _characterManager.GetCharacterByCharacterID(characterID);
            string newName = "";
            string newFirstName = "";
            string newMiddleName = "";
            string newLastName = "";
            string newGenderIdentity = "";
            string newBirthSex = "";
            string newSexuality = "";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.UpdateCharacter(userCharacter, newName, newFirstName, newMiddleName, newLastName);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        // deactivate character
        [TestMethod]
        public void TestDeactivateCharacterReturnsTrueForSuccess()
        {
            // arrange
            string user = "test1";
            int characterID = 2;
            string characterName = "Homer";
            bool expectedResult = true;
            bool actualResult = false;

            // assert
            actualResult = _characterManager.DeactivateCharacter(user, characterID, characterName);

            // act
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestDeactivateCharacterReturnsFalseForNotCreator()
        {
            // arrange
            string user = "test3";
            int characterID = 2;
            string characterName = "Homer";
            bool expectedResult = false;
            bool actualResult = true;

            // assert
            actualResult = _characterManager.DeactivateCharacter(user, characterID, characterName);

            // act
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestDeactivateCharacterReturnsFalseForNoCharacter()
        {
            // arrange
            string user = "test1";
            int characterID = 0;
            string characterName = "Homer";
            bool expectedResult = false;
            bool actualResult = true;

            // assert
            actualResult = _characterManager.DeactivateCharacter(user, characterID, characterName);

            // act
            Assert.AreEqual(expectedResult, actualResult);

        }



        // traits
        [TestMethod]
        public void TestGetAllTraits()
        {
            // arrange
            int expectedNumber = 3;
            int actualNumber = 0;

            // act
            actualNumber = _characterManager.GetAllTraits().Count;

            // assert
            Assert.AreEqual(expectedNumber, actualNumber);

        }

        [TestMethod]
        public void TestAddTraitToCharacterReturnsTrueForSuccess()
        {
            // arrange
            bool expectedResult = true;
            bool actualResult = false;
            int character = 3;
            string trait = "Smart";

            // act
            actualResult = _characterManager.AddTraitToCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
            
        }

        [TestMethod]
        public void TestAddTraitToCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            bool expectedResult = false;
            bool actualResult = true;
            int character = 99;
            string trait = "Smart";

            // act
            actualResult = _characterManager.AddTraitToCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddTraitToCharacterReturnsFalseForInvalidTrait()
        {
            // arrange
            bool expectedResult = false;
            bool actualResult = true;
            int character = 3;
            string trait = "Other";

            // act
            actualResult = _characterManager.AddTraitToCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetCharacterTraitsIsSuccessful()
        {
            // arrange
            int character = 2;
            int expectedResult = 1;
            int actualResult = 0;

            // act
            actualResult = _characterManager.GetAllTraitsForCharacter(character).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestGetCharacterTraitsFails()
        {
            // arrange
            int character = 99;
            int expectedResult = 0;
            int actualResult = 99;

            // act
            actualResult = _characterManager.GetAllTraitsForCharacter(character).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveTraitFromCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string trait = "Dumb";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.RemoveTraitFromCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveTraitFromCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 9;
            string trait = "Dumb";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveTraitFromCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveTraitFromCharacterReturnsFalseForInvalidTrait()
        {
            // arrange
            int character = 2;
            string trait = "Fat";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveTraitFromCharacter(character, trait);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }



        // skills
        [TestMethod]
        public void TestGetAllSkills()
        {
            // arrange
            int expectedNumber = 3;
            int actualNumber = 0;

            // act
            actualNumber = _characterManager.GetAllSkills().Count;

            // assert
            Assert.AreEqual(expectedNumber, actualNumber);

        }

        [TestMethod]
        public void TestGetAllSkillsForCharacter()
        {
            // arrange
            int character = 2;
            int expectedResult = 1;
            int actualResult = 0;

            // act
            actualResult = _characterManager.GetAllSkillsForCharacter(character).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestGetAllSkillsForCharacterReturnsZero()
        {
            // arrange
            int character = 3;
            int expectedResult = 0;
            int actualResult = 3;

            // act
            actualResult = _characterManager.GetAllSkillsForCharacter(character).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestAddSkillToCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string skill = "Running";
            string description = "This is a lie.";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.AddSkillToCharacter(character, skill, description);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddSkillToCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 99;
            string skill = "Running";
            string description = "This doesn't matter.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.AddSkillToCharacter(character, skill, description);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddSkillToCharacterReturnsFalseForInvalidSkill()
        {
            // arrange
            int character = 2;
            string skill = "Baking";
            string description = "This doesn't matter.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.AddSkillToCharacter(character, skill, description);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateSkillForCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string skill = "Singing";
            string oldDescription = "He's not actually good at singing, this is just an example.";
            string newDescription = "This is a lie.";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.UpdateSkillForCharacter(character, skill, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateSkillForCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 8;
            string skill = "Singing";
            string oldDescription = "He's not actually good at singing, this is just an example.";
            string newDescription = "This is a lie.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateSkillForCharacter(character, skill, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateSkillForCharacterReturnsFalseForInvalidSkill()
        {
            // arrange
            int character = 2;
            string skill = "Eating";
            string oldDescription = "Doesn't matter.";
            string newDescription = "Doesn't matter.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateSkillForCharacter(character, skill, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateSkillForCharacterReturnsFalseForInvalidOldDescription()
        {
            // arrange
            int character = 2;
            string skill = "Singing";
            string oldDescription = "Bad description.";
            string newDescription = "This is a lie.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateSkillForCharacter(character, skill, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRemoveSkillFromCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string skill = "Singing";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.RemoveSkillFromCharacter(character, skill);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveSkillFromCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 9;
            string skill = "Singing";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveSkillFromCharacter(character, skill);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveSkillFromCharacterReturnsFalseForInvalidSkill()
        {
            // arrange
            int character = 2;
            string skill = "Eating";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveSkillFromCharacter(character, skill);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }


        // interests
        [TestMethod]
        public void TestGetAllInterestsForCharacterIsSuccessful()
        {
            // arrange
            int characterID = 2;
            int expectedLikes = 2;
            int actualLikes = 0;
            int expectedDislikes = 1;
            int actualDislikes = 0;

            // act
            foreach(CharacterLikeDislike interest in _characterManager.GetAllInterestsForCharacter(characterID))
            {
                if(interest.LikeDislikeType == "Like")
                {
                    actualLikes++;
                }
                else
                {
                    actualDislikes++;
                }
            }

            // assert
            Assert.AreEqual(expectedLikes, actualLikes);
            Assert.AreEqual(expectedDislikes, actualDislikes);

        }

        [TestMethod]
        public void TestAddInterestToCharacterReturnsTrueForSuccess()
        {
            // arrange
            int characterID = 2;
            string likeDislikeType = "Like";
            string interest = "Eating";
            string description = "He loves eating all kinds of food.";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.AddInterestToCharacter(characterID, likeDislikeType, interest, description);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestAddInterestToCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int characterID = 99;
            string likeDislikeType = "Like";
            string interest = "Eating";
            string description = "He loves eating all kinds of food.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.AddInterestToCharacter(characterID, likeDislikeType, interest, description);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRemoveInterestFromCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string type = "Like";
            string interest = "Beer";
            string description = "Beer are his favorite drink.";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.RemoveInterestFromCharacter(character, type, interest, description);

            // arrange
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestRemoveInterestFromCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 99;
            string type = "Like";
            string interest = "Beer";
            string description = "Beer are his favorite drink.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveInterestFromCharacter(character, type, interest, description);

            // arrange
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRemoveInterestFromCharacterReturnsFalseForInvalidLikeDislikeType()
        {
            // arrange
            int character = 2;
            string type = "Dislike";
            string interest = "Beer";
            string description = "Beer are his favorite drink.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveInterestFromCharacter(character, type, interest, description);

            // arrange
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRemoveInterestFromCharacterReturnsFalseForInvalidInterest()
        {
            // arrange
            int character = 2;
            string type = "Like";
            string interest = "Peaches";
            string description = "Beer are his favorite drink.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.RemoveInterestFromCharacter(character, type, interest, description);

            // arrange
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateInterestForCharacterReturnsTrueForSuccess()
        {
            // arrange
            int character = 2;
            string type = "Like";
            string oldInterest = "Beer";
            string newInterest = "Duff Beer";
            string oldDescription = "Beer are his favorite drink.";
            string newDescription = "Duff Beer is his favorite brand of beer.";
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _characterManager.UpdateInterestForCharacter(character, type, oldInterest, newInterest, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdateInterestForCharacterReturnsFalseForInvalidCharacter()
        {
            // arrange
            int character = 9;
            string type = "Like";
            string oldInterest = "Beer";
            string newInterest = "Duff Beer";
            string oldDescription = "Beer are his favorite drink.";
            string newDescription = "Duff Beer is his favorite brand of beer.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateInterestForCharacter(character, type, oldInterest, newInterest, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestUpdateInterestForCharacterReturnsFalseForInvalidOldInterest()
        {
            // arrange
            int character = 2;
            string type = "Like";
            string oldInterest = "Soda";
            string newInterest = "Duff Beer";
            string oldDescription = "Beer are his favorite drink.";
            string newDescription = "Duff Beer is his favorite brand of beer.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateInterestForCharacter(character, type, oldInterest, newInterest, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateInterestForCharacterReturnsFalseForInvalidOldDescription()
        {
            // arrange
            int character = 2;
            string type = "Like";
            string oldInterest = "Beer";
            string newInterest = "Duff Beer";
            string oldDescription = "bad description.";
            string newDescription = "Duff Beer is his favorite brand of beer.";
            bool expectedResult = false;
            bool actualResult = true;

            // act
            actualResult = _characterManager.UpdateInterestForCharacter(character, type, oldInterest, newInterest, oldDescription, newDescription);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }




        // NEW

        [TestMethod]
        public void TestViewAccessForCharacterIsSuccessful()
        {
            // arrange
            int characterID = 2;
            int expectedResult = 1;
            int actualResult = 0;

            // act
            actualResult = _characterManager.GetAccessForCharacter(characterID).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void TestViewAccessForCharacterReturnsNothing()
        {
            // arrange
            int characterID = 99;
            int expectedResult = 0;
            int actualResult = 99;

            // act
            actualResult = _characterManager.GetAccessForCharacter(characterID).Count;

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
