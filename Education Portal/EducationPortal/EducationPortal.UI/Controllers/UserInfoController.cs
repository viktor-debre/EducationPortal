using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        private readonly IUserInformationService _userInformation;

        public UserInfoController(IUserInformationService userInformation)
        {
            _userInformation = userInformation;
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            ViewBag.AuthorizedUser = await _userInformation.GetUserInfo(User.Identity.Name);
            return View();
        }
    }
}
