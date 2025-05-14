using DataDomain;
using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCCharacterCreator.Controllers
{
    public class CharacterController : Controller
    {
        CharacterManager _characterManager = new CharacterManager();
        UserManager _userManager = new UserManager();

        // GET: CharacterController

        [Authorize]
        public ActionResult Index()
        {
            string user = User.Identity.Name;

            List<UserCharacter> userCharacters = new List<UserCharacter>();
            List<UserPermission> sharedCharacters = new List<UserPermission>();
            try
            {
                userCharacters = _characterManager.GetCharactersByUser(user);
                sharedCharacters = _characterManager.GetAccessCharactersByUser(user);
                ViewBag.Characters = sharedCharacters;
            }
            catch (Exception)
            {
                View();
            }
            return View(userCharacters);
        }

        // GET: CharacterController/Details/5

        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                string user = User.Identity.Name;

                UserCharacter character = _characterManager.GetCharacterByCharacterID(id);
                if(character.CreatorID != user)
                {
                    bool access = false;
                    List<UserPermission> permissions = _characterManager.GetAccessForCharacter(id);
                    foreach (UserPermission permission in permissions)
                    {
                        if (permission.UserID == User.Identity.Name)
                        {
                            access = true;
                            ViewBag.AccessType = permission.AccessType;
                            break;
                        }
                    }
                    if (!access)
                    {
                        TempData["MessageDanger"] = "You do not have viewing access for this character!";
                        return RedirectToAction("Details", "Character", new { id = character.CharacterID });
                    }
                }

                populateViewBags(id, 0);
                
                return View(character);
            }
            catch (Exception)
            {
                return View(id);
            }
            
        }

        // GET: CharacterController/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterController/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCharacter character)
        {
            string user = User.Identity.Name;//_userManager.SelectUserByEmail(User.Identity.Name).Username;
            character.CreatorID = user;

            if (ModelState.IsValid)
            {
                try
                {
                    _characterManager.CreateNewCharacter(character);

                    TempData["MessageSuccess"] = "Successfully added " + character.CharacterName + "!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["MessageDanger"] = "Error adding " + character.CharacterName + ".";
                    return View(character);
                }
            }
            else
            {
                TempData["MessageDanger"] = "Error adding character. " + User.Identity.Name;
                return View(character);
            }
        }

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id, int p)
        {
            try
            {
                UserCharacter character = _characterManager.GetCharacterByCharacterID(id);
                if(character.CreatorID != User.Identity.Name)
                {
                    bool editor = false;
                    List<UserPermission> permissions = _characterManager.GetAccessForCharacter(id);
                    foreach(UserPermission permission in permissions)
                    {
                        if(permission.UserID == User.Identity.Name)
                        {
                            if(permission.AccessType == "Editor")
                            {
                                editor = true;
                            }
                            break;
                        }
                    }
                    if (!editor)
                    {
                        TempData["MessageDanger"] = "You do not have edit access for this character!";
                        return RedirectToAction("Details", "Character", new {id = character.CharacterID});
                    }

                }


                populateViewBags(id, p);

                return View(character);
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error.";
                return View();
            }
            
        }

        // POST: CharacterController/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserCharacter newCharacter)
        {
            try
            {
                populateViewBags(id, 0);

                UserCharacter character = _characterManager.GetCharacterByCharacterID(id);

                if(ModelState.IsValid || true)
                {
                    bool result = _characterManager.UpdateCharacter(character, newCharacter.CharacterName, newCharacter.CharacterFirstName, newCharacter.CharacterMiddleName, newCharacter.CharacterLastName);
                    if (result)
                    {
                        TempData["MessageSuccess"] = "Character was updated successfully!";
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        TempData["MessageSecondary"] = "Character was updated.";
                        return RedirectToAction("Details", new { id = id });

                    }
                }
                else
                {
                    TempData["MessageDanger"] = "An unexpected error occured.";
                    return RedirectToAction("Details", new { id = id });
                }

            }
            catch
            {
                TempData["MessageDanger"] = "Error.";
                return RedirectToAction(nameof(Index));
            }
        }
        

        public ActionResult RemoveTrait(int id, string traitID)
        {
          
            try
            {

                bool result = _characterManager.RemoveTraitFromCharacter(id, traitID);
                if (result)
                {
                    TempData["MessageSuccess"] = "Trait was removed.";
                    return RedirectToAction("Edit", new { id = id, p = 1 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error removing the trait.";
                    return RedirectToAction("Edit", new { id = id, p = 1 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";

                return RedirectToAction("Edit", new { id = id, p = 1 });
            }

        }
        public ActionResult AddTrait(int id, string traitID)
        {
            try
            {
                bool result = _characterManager.AddTraitToCharacter(id, traitID);
                if (result)
                {
                    TempData["MessageSuccess"] = "Trait was added.";
                    return RedirectToAction("Edit", new { id = id, p = 1 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error adding the trait.";
                    return RedirectToAction("Edit", new { id = id, p = 1 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";
                return RedirectToAction("Edit", new { id = id, p = 1 });
            }
        }

        public ActionResult RemoveSkill(int id, string skillID)
        {
            try
            {
                bool result = _characterManager.RemoveSkillFromCharacter(id, skillID);
                if (result)
                {
                    TempData["MessageSuccess"] = "The skill was removed.";
                    return RedirectToAction("Edit", new { id = id, p = 2 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error removing the skill.";
                    return RedirectToAction("Edit", new { id = id, p = 2 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";
                return RedirectToAction("Edit", new { id = id, p = 2 });
            }
        }
        public ActionResult AddSkill(int id, string skillID, string desc)
        {
            try
            {
                if (desc == null)
                {
                    desc = "";
                }

                bool result = _characterManager.AddSkillToCharacter(id, skillID, desc);
                if (result)
                {
                    TempData["MessageSuccess"] = "The skill was added.";
                    return RedirectToAction("Edit", new { id = id, p = 2 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error adding the skill.";
                    return RedirectToAction("Edit", new { id = id, p = 2 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";
                return RedirectToAction("Edit", new { id = id, p = 2 });
            }
        }


        public ActionResult AddLikeDislike(int id, string likeDislikeType, string interest, string desc)
        {
            try
            {
                string name = _characterManager.GetCharacterByCharacterID(id).CharacterName;

                List<CharacterLikeDislike> interestList = _characterManager.GetAllInterestsForCharacter(id);
                bool taken = false;
                string type = "";
                foreach(CharacterLikeDislike characterLikeDislike in  interestList)
                {
                    if(characterLikeDislike.CharacterInterest ==  interest)
                    {
                        taken = true;
                        type = characterLikeDislike.LikeDislikeType + "s";
                        break;
                    }
                }
                if (taken)
                {
                    TempData["MessageWarning"] = name + " already " + type + " " + interest + ".";
                    return RedirectToAction("Edit", new { id = id, p = 3 });

                }
                bool result = _characterManager.AddInterestToCharacter(id, likeDislikeType, interest, desc);
                if (result)
                {
                    TempData["MessageSuccess"] = "The " + likeDislikeType + " was added.";
                    return RedirectToAction("Edit", new { id = id, p = 3 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error adding the " + likeDislikeType + ".";
                    return RedirectToAction("Edit", new { id = id, p = 3 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";
                return RedirectToAction("Edit", new { id = id, p = 3 });
            }
        }

        public ActionResult RemoveInterest(int id, string interest, string type, string desc)
        {
            try
            {
                bool result = _characterManager.RemoveInterestFromCharacter(id, type, interest, desc);

                if(result)
                {
                    TempData["MessageSuccess"] = "The like or dislike was removed.";
                    return RedirectToAction("Edit", new { id = id, p = 3 });
                }
                else
                {
                    TempData["MessageDanger"] = "There was an error removing the like or dislike.";
                    return RedirectToAction("Edit", new { id = id, p = 3 });
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "An unexpected error occured.";
                return RedirectToAction("Edit", new { id = id, p = 3 });
            }
        }



        private void populateViewBags(int id, int page)
        {
            ViewBag.Page = page;

            List<CharacterTraitVM> traitList = _characterManager.GetAllTraitsForCharacter(id);
            List<CharacterSkill> skillList = _characterManager.GetAllSkillsForCharacter(id);

            List<CharacterLikeDislike> interestList = _characterManager.GetAllInterestsForCharacter(id);
            List<CharacterLikeDislike> likeList = new List<CharacterLikeDislike>();
            List<CharacterLikeDislike> dislikeList = new List<CharacterLikeDislike>();

            foreach (CharacterLikeDislike interest in interestList)
            {
                if (interest.LikeDislikeType == "like")
                {
                    likeList.Add(interest);
                }
                else if (interest.LikeDislikeType == "dislike")
                {
                    dislikeList.Add(interest);
                }
            }

            ViewBag.TraitList = traitList;
            ViewBag.SkillList = skillList;
            ViewBag.LikeList = likeList;
            ViewBag.DislikeList = dislikeList;

            List<Trait> allTraits = _characterManager.GetAllTraits();
            List<Trait> availableTraits = new List<Trait>();
            foreach (var trait in allTraits)
            {
                bool available = true;
                foreach (var charTrait in traitList)
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
            ViewBag.AvailableTraits = availableTraits;

            List<Skill> allSkills = _characterManager.GetAllSkills();
            List<Skill> availableSkills = new List<Skill>();

            foreach (var skill in allSkills)
            {
                bool available = true;
                foreach (var charSkill in skillList)
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

            ViewBag.AvailableSkills = availableSkills;
        }


        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            UserCharacter character = _characterManager.GetCharacterByCharacterID(id);

            if (character.CreatorID != User.Identity.Name)
            {
                TempData["MessageDanger"] = "Invalid access!";
                return RedirectToAction("Index", "Character");
            }

            return View(character);
        }

        // POST: CharacterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserCharacter character)
        {
            try
            {
                if (true)
                {
                    character = _characterManager.GetCharacterByCharacterID(id);
                    bool result = _characterManager.DeactivateCharacter(character.CreatorID, character.CharacterID, character.CharacterName);
                    if(result)
                    {
                        TempData["MessageSuccess"] = "Character deleted.";

                    }
                    else
                    {
                        TempData["MessageWarning"] = "Character not deleted.";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                TempData["MessageDanger"] = "An unexpected error occured.\n" + e.Message;
                return View(id);
            }
        }



    }

}
