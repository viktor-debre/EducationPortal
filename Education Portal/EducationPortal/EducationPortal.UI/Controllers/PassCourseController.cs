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
            await _userPassCourse.TakeCourse(course, user.Id);

            return RedirectToAction("StartCourse");
        }

        public async Task<IActionResult> PassCourses()
        {
            var coursesInDb = await _courseEditService.GetCourses();
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            var startedCourses = await _userPassCourse.GetStartedCourses(user.Id);
            ViewBag.UserCourses = startedCourses;
            List<CourseView> courses = new List<CourseView>();
            foreach (var course in startedCourses)
            {
                var item = coursesInDb.FirstOrDefault(x => x.Id == course.CourseId);
                if (item != null)
                {
                    courses.Add(item);
                }
            }

            return View(courses);
        }

        public async Task<IActionResult> StartPassCourse(int? id)
        {
            var course = await _courseEditService.GetByIdCourse(id ?? 0);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> PassMaterial(int? id, string? name)
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            if (id != null && name != null)
            {
                var course = await _courseEditService.GetByIdCourse(id ?? 0);
                await _userPassCourse.PassMaterial(course, name, user.Id);
            }

            return RedirectToAction("StartPassCourse");
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
