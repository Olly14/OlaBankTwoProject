using System.Threading.Tasks;
using Bank.App.CustomSecurity;
using Bank.App.Models;
using Bank.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(string ReturnUrl, LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                var identityUser = await _userManager.FindByEmailAsync(model.Email);
                
                if (signInResult.Succeeded && await  _userManager.IsInRoleAsync(identityUser, "Bank Admin"))
                {
                    if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "AppUsers");
                }
                else
                {
                    return RedirectToAction("AppUserIndex", "AppUsers", new {id=GuidEncoder.Encode(identityUser.Id)});
                }

                ModelState.AddModelError("", "Invalid Login Attempt");

            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AcccounIsBlocked()
        {
            return View();
        }
    }
}