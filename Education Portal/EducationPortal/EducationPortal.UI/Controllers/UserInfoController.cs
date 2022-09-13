using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInformationService _userInformation;

        public UserInfoController(IUserInformationService userInformation)
        {
            _userInformation = userInformation;
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            ViewBag.AuthorizedUser = _userInformation.GetUserInfo(User.Identity.Name);
            return View();
        }
    }
}
