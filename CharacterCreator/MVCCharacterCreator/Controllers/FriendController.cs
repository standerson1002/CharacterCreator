using DataDomain;
using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace MVCCharacterCreator.Controllers
{
    public class FriendController : Controller
    {
        UserManager _userManager = new UserManager();

        [Authorize]
        public ActionResult Index()
        {
            string user = User.Identity.Name;
            List<UserFriend> userFriends = new List<UserFriend>();
            try
            {
                userFriends = _userManager.RetrieveFriendList(user);
                List<UserFriend> pending = _userManager.RetrievePendingFriendRequests(user);
                List<UserFriend> waiting = _userManager.RetrieveFriendRequests(user);
                ViewBag.Pending = pending;
                ViewBag.Waiting = waiting;
            }
            catch (Exception)
            {
                return View();
            }

            return View(userFriends);
        }

        [Authorize]
        public ActionResult Details(string id)
        {
            try
            {
                string user = User.Identity.Name;
                if (user != id && id != null)
                {
                    User friend = _userManager.RetrieveUserByUsername(id);
                    if (friend != null)
                    {
                        UserFriend relationship = _userManager.RetrieveFriendStatus(user, id);
                        if (relationship != null)
                        {
                            if(relationship.UserFriendStatus == "blocker")
                            {
                                TempData["MessageWarning"] = "Invalid user.";
                                return RedirectToAction(nameof(Index));
                            }
                            ViewBag.Relationship = relationship;
                        }
                        else
                        {
                            ViewBag.Relationship = new UserFriend();
                        }
                        return View(friend);
                    }
                }

                TempData["MessageWarning"] = "Invalid user.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = "Error viewing profile!";
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                string user = User.Identity.Name;
                _userManager.RemoveFriend(user, id);
                TempData["MessageWarning"] = "Friend removed!";
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error removing friend!";
            }

            return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public ActionResult Send(string id)
        {
            try
            {
                string user = User.Identity.Name;
                _userManager.SendFriendRequest(user, id);                
                TempData["MessagePrimary"] = "Friend request sent!";
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error sending friend request!";
            }

            return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public ActionResult Accept(string id)
        {
            try
            {
                string user = User.Identity.Name;
                TempData["MessageSuccess"] = "Friend request accepted!";
                _userManager.AcceptFriendRequest(user, id);
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error accepting friend request!";
            }

            return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public ActionResult Reject(string id)
        {
            try
            {
                string user = User.Identity.Name;
                _userManager.RejectFriendRequest(user, id);
                TempData["MessageWarning"] = "Friend request rejected!";
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error rejecting friend request!";
            }

            return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public ActionResult Cancel(string id)
        {
            try
            {
                string user = User.Identity.Name;
                _userManager.CancelPendingFriendRequest(user, id);
                TempData["MessageWarning"] = "Friend request canceled!";
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error canceling friend request!";
            }

            return RedirectToAction("Details", new { id = id });
        }


        [Authorize]
        public ActionResult Block(string id)
        {
            try
            {
                string user = User.Identity.Name;
                bool result = _userManager.BlockUser(user, id);
                if (result)
                {
                    TempData["MessageWarning"] = "Blocked user!";
                }
                else
                {
                    TempData["MessageDanger"] = "Error blocking user.";
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error blocking user!"; 
            }

           return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public ActionResult Unblock(string id)
        {
            try
            {
                string user = User.Identity.Name;
                bool result = _userManager.UnblockUser(user, id);
                if (result)
                {
                    TempData["MessageWarning"] = "Unblocked user!";
                }
                else
                {
                    TempData["MessageDanger"] = "Error unblocking user.";
                }
            }
            catch (Exception)
            {
                TempData["MessageDanger"] = "Error unblocking user!";
            }

            return RedirectToAction("Details", new { id = id });

        }


    }

}
