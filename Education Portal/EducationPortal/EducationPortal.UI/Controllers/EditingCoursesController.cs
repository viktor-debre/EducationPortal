using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class EditingCoursesController : Controller
    {
        private readonly ICourseEditService _courseEditService;
        private readonly IMaterialEditService _materialEditService;
        private readonly ISkillEditService _skillEditService;

        public EditingCoursesController(
            ICourseEditService courseEditService,
            IMaterialEditService materialEditService,
            ISkillEditService skillEditService
            )
        {
            _courseEditService = courseEditService;
            _materialEditService = materialEditService;
            _skillEditService = skillEditService;
        }

        public async Task<IActionResult> Courses()
        {
            var courses = await _courseEditService.GetCourses();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            var materials = await _materialEditService.GetMaterials();
            ViewBag.Materials = new SelectList(materials, "Id", "Name");
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

        public async Task<IActionResult> Details(int? id)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(id ?? 0);
            if (course != null)
            {
                return View(course);
            }

            return NotFound();
        }
    }
}
