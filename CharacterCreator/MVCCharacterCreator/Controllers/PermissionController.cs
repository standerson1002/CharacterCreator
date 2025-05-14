using DataDomain;
using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCCharacterCreator.Controllers
{
    public class PermissionController : Controller
    {
        CharacterManager _characterManager = new CharacterManager();
        UserManager _userManager = new UserManager();

        // GET: PermissionController

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: PermissionController/Details/5

        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                List<UserPermission> permissions = _characterManager.GetAccessForCharacter(id);
                UserCharacter character = _characterManager.GetCharacterByCharacterID(id);

                if(character.CreatorID != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }

                ViewBag.Character = character;
                foreach(UserPermission permission in permissions)
                {
                    permission.CharacterName = character.CharacterName;
                }
                return View(permissions);
            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = e.Message;
                return View();
            }
        }

        // GET: PermissionController/Create

        [Authorize]
        public ActionResult Create(int id)
        {
            try
            {
                UserCharacter character = _characterManager.GetCharacterByCharacterID(id);
                if (character.CreatorID != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }

                PopulateShareInfo(id);
            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = e.Message;
            }
            

            return View();
        }

        // POST: PermissionController/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserPermission access)
        {
            try
            {
                if(access.CreatorID != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }


                if (ModelState.IsValid)
                {
                    if(_characterManager.GiveAccessToCharacter(access.UserID, access.CreatorID, access.CharacterID, access.AccessType))
                    {
                        TempData["MessageSuccess"] = "Permission added for " + access.UserID + "!";
                        return RedirectToAction("Details", new { id = access.CharacterID });
                    }
                    else
                    {
                        TempData["MessageDanger"] = "Invalid permission!";
                    }
                }
                else
                {
                    PopulateShareInfo(access.CharacterID);
                }
            }
            catch(Exception e) 
            {
                TempData["MessageDanger"] = e.Message;
            }

            return View(access);
        }

        // GET: PermissionController/Edit/5

        [Authorize]
        public ActionResult Edit(int character, string user, string access, string creator, string name)
        {
            try
            {
                if(creator != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }


                List<string> accessTypes = new List<string>();
                accessTypes.Add("Editor"); accessTypes.Add("Viewer");
                ViewBag.AccessTypes = accessTypes;

                ViewBag.Character = character;
                ViewBag.User = user;
                ViewBag.Creator = creator;
                ViewBag.Name = name;


                UserPermission permission = new UserPermission()
                {
                    CharacterID = character,
                    UserID = user,
                    AccessType = access,
                    CreatorID = "",
                    CharacterName = ""
                };

                return View(permission);
            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = e.Message;
            }

            return View();
        }

        // POST: PermissionController/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserPermission collection)
        {
            try
            {
                if (collection.CreatorID != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }

                if (ModelState.IsValid)
                {

                    _characterManager.GiveAccessToCharacter(collection.UserID, collection.CreatorID, collection.CharacterID, collection.AccessType);
                    TempData["MessageSuccess"] = "Permission updated for " + collection.UserID + "!";
                    return RedirectToAction("Details", new { id = collection.CharacterID });

                }
                else
                {
                    TempData["MessageDanger"] = "Invalid permission!";

                }

            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = e.Message;
                
                List<string> accessTypes = new List<string>();
                accessTypes.Add("Editor"); accessTypes.Add("Viewer");
                ViewBag.AccessTypes = accessTypes;

            }

            return View(collection);
        }

        [Authorize]
        public ActionResult Delete(int character, string user, string creator)
        {
            try
            {
                if (creator != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Invalid access!";
                    return RedirectToAction("Index", "Character");
                }

                _characterManager.GiveAccessToCharacter(user, creator, character, "No Access");
                TempData["MessageSuccess"] = "Removed access from " + user + "!";
            }
            catch(Exception e)
            {
                TempData["MessageDanger"] = e.Message;
            }

            return RedirectToAction("Details", new { id = character });
        }

        // Helpers
        
        public void PopulateShareInfo(int character)
        {
            string userStr = User.Identity.Name;
            User user = _userManager.RetrieveUserByUsername(userStr);
            List<string> availableFriends = new List<string>();
            List<UserFriend> friends = _userManager.RetrieveFriendList(userStr);
            List<UserPermission> permissions = _characterManager.GetAccessForCharacter(character);

            foreach (UserFriend friend in friends)
            {
                bool available = true;

                foreach (UserPermission permission in permissions)
                {
                    if (friend.UserFriendID == permission.UserID)
                    {
                        available = false;
                    }
                }
                if (available)
                {
                    availableFriends.Add(friend.UserFriendID);
                }
            }

            List<string> accessTypes = new List<string>();
            accessTypes.Add("Editor"); accessTypes.Add("Viewer");
            ViewBag.AccessTypes = accessTypes;

            ViewBag.Character = _characterManager.GetCharacterByCharacterID(character);
            ViewBag.AvailableFriends = availableFriends;
        }


    }




}
