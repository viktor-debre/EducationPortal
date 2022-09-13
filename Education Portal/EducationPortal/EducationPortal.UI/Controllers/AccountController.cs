using EducationPortal.UI.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationPortal.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserView user = _accountService.AuthenticateUserByName(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Home", "Index");
                }

                ModelState.AddModelError("", "Incorrect name or password");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(UserView user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims,
                                                   "ApplicationCookie",
                                                   ClaimsIdentity.DefaultNameClaimType,
                                                   ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
