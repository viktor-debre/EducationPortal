using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class EditingCoursesController : Controller
    {
        private readonly ICourseEditService _courseEditService;

        public EditingCoursesController(ICourseEditService courseEditService)
        {
            _courseEditService = courseEditService;
        }

        public async Task<IActionResult> Courses()
        {
            var skills = await _courseEditService.GetCourses();
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseView course)
        {
            if (ModelState.IsValid)
            {
                if (course.Id == 0)
                {
                    await _courseEditService.SetCourse(course);
                }

                return RedirectToAction("Courses");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                CourseView? course = await _courseEditService.GetByIdCourse(id ?? 0);
                if (course != null)
                {
                    return View(course);
                }

                return NotFound();
            }

            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseView course)
        {
            await _courseEditService.UpdateCourse(course);

            return RedirectToAction("Courses");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(id ?? 0);
            if (course != null)
            {
                _courseEditService.RemoveCourse(course);
                return RedirectToAction("Courses");
            }

            return NotFound();
        }
    }
}
