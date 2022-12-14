using EducationPortal.Domain.Entities;
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
        private readonly ICourseSelectListsService _courseSelectListsService;

        public EditingCoursesController(ICourseEditService courseEditService, ICourseSelectListsService courseSelectListsService)
        {
            _courseEditService = courseEditService;
            _courseSelectListsService = courseSelectListsService;
        }

        public async Task<IActionResult> Courses()
        {
            var courses = await _courseEditService.GetCourses();
            return View(courses);
        }

        public async Task<IActionResult> Create()
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
                await _courseEditService.RemoveCourse(course);
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

        public async Task<IActionResult> AddMaterials(int? id)
        {
            if (id != null)
            {
                var model = await _courseSelectListsService.GetAllMaterialsSelectList((int)id);
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterials(CourseMaterialsView? courseMaterials)
        {
            await _courseEditService.AddMaterialsInCourse(courseMaterials);
            return RedirectToAction("Courses");
        }

        public async Task<IActionResult> AddSkills(int? id)
        {
            if (id != null)
            {
                var model = await _courseSelectListsService.GetAllSkillsSelectList((int)id);
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddSkills(CourseSkillView? courseSkills)
        {
            await _courseEditService.AddSkillsInCourse(courseSkills);
            return RedirectToAction("Courses");
        }
    }
}
