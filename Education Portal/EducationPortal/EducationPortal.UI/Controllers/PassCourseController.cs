using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class PassCourseController : Controller
    {
        private readonly IUserCoursePassService _userCoursePassService;

        public PassCourseController(IUserCoursePassService userCoursePassService)
        {
            _userCoursePassService = userCoursePassService;
        }

        public async Task<IActionResult> StartCourse()
        {
            var availableCourses = await _userCoursePassService.AvailableCourses(User.Identity.Name);
            return View(availableCourses);
        }

        public async Task<IActionResult> TakeCourse(int? id)
        {
            await _userCoursePassService.TakeCourse(id, User.Identity.Name);
            return RedirectToAction("StartCourse");
        }

        public async Task<IActionResult> PassCourses()
        {
            var userName = User.Identity.Name;
            var courses = await _userCoursePassService.StartedCourses(userName);
            ViewBag.UserCourses = await _userCoursePassService.StartedCoursesGetStatusInfo(userName);
            return View(courses);
        }

        public async Task<IActionResult> StartPassCourse(int? id)
        {
            var userName = User.Identity.Name;
            if (id != null)
            {
                CourseView course = await _userCoursePassService.GetCourseToPass(id);
                ViewBag.CourseMaterial = await _userCoursePassService.PassedMaterials(id, userName);
                return View(course);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PassMaterial(int? id, string? name)
        {
            var userName = User.Identity.Name;
            await _userCoursePassService.PassMaterial(id, name, userName);
            return RedirectToAction("StartPassCourse", new { id });
        }

        public async Task<IActionResult> PassedCourses()
        {
            List<CourseView> courses = await _userCoursePassService.PassedCourses(User.Identity.Name);
            return View(courses);
        }
    }
}
