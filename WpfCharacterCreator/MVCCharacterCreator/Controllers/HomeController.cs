using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCharacterCreator.Models;
using System.Diagnostics;

namespace MVCCharacterCreator.Controllers
{
    public class HomeController : Controller
    {

        // new to include identity manager classes
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
               UserManager<IdentityUser> userManager,
               SignInManager<IdentityUser> signInManager)
        {
            // new to instantiate identity manager classes
            _userManager = userManager;
            _signInManager = signInManager;

            _logger = logger;
        }



        // added to get a legacy logiclayer employee manager and data domain employeeVM for an access token
        private LogicLayer.IUserManager _serManager = new LogicLayer.UserManager();
        private AccessToken _accessToken = new AccessToken("");

        private void getAccessToken()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string email = User.Identity.Name;
                try
                {
                    _accessToken = new AccessToken(email);
                }
                catch { }
            }
            else
            {
                return;
            }
        }


        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
