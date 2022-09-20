using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class PassCourseController : Controller
    {
        public IUserPassCourseService _userPassCourse;
        public IUserInformationService _userInformation;

        public PassCourseController(IUserPassCourseService userPassCourse, IUserInformationService userInformation)
        {
            _userPassCourse = userPassCourse;
            _userInformation = userInformation;
        }

        public async Task<IActionResult> StartCourse()
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            var availableCourses = await _userPassCourse.GetAvailableCourses(user.Id);
            return View(availableCourses);
        }

        public async Task<IActionResult> TakeCourse(CourseView? course)
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            _userPassCourse.TakeCourse(course, user.Id);

            return RedirectToAction("StartCourse");
        }

        public async Task<IActionResult> PassCourse()
        {
            return View();
        }

        public async Task<IActionResult> PassedCourses()
        {
            return View();
        }
    }
}
