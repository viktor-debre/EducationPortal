using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class PassCourseController : Controller
    {
        private readonly IUserPassCourseService _userPassCourse;
        private readonly IUserInformationService _userInformation;
        private readonly ICourseEditService _courseEditService;

        public PassCourseController(IUserPassCourseService userPassCourse, IUserInformationService userInformation, ICourseEditService courseEditService)
        {
            _userPassCourse = userPassCourse;
            _userInformation = userInformation;
            _courseEditService = courseEditService;
        }

        public async Task<IActionResult> StartCourse()
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            var availableCourses = await _userPassCourse.GetAvailableCourses(user.Id);
            return View(availableCourses);
        }

        public async Task<IActionResult> TakeCourse(int? id)
        {
            var course = await _courseEditService.GetByIdCourse(id ?? 0);
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            _userPassCourse.TakeCourse(course, user.Id);

            return RedirectToAction("StartCourse");
        }

        public async Task<IActionResult> PassCourses()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PassCourse(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PassMaterial(CourseView course, string name)
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            _userPassCourse.PassMaterial(course, name, user.Id);
            return View();
        }

        public async Task<IActionResult> PassedCourses()
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            var passedCourses = await _userPassCourse.GetPassedCourses(user.Id);
            List<CourseView> courses = new List<CourseView>();
            foreach (var course in await _courseEditService.GetCourses())
            {
                var findedCourse = passedCourses.FirstOrDefault(x => x.CourseId == course.Id);
                if (findedCourse != null)
                {
                    courses.Add(course);
                }
            }

            return View(courses);
        }
    }
}
