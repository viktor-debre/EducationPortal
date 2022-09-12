using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    internal class UserInfoController : Controller
    {
        private readonly IUserInformationService _userInformation;

        public UserInfoController(IUserInformationService userInformation)
        {
            _userInformation = userInformation;
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            return View(_userInformation.GetUserInfo("Viktor"));
        }
    }
}
