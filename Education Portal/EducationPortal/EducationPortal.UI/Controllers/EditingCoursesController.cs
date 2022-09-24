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

        public async Task<IActionResult> AddMaterials(int? id)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(id ?? 0);
            if (course != null)
            {
                var materials = await _materialEditService.GetMaterials();
                var selectMaterialsList = new SelectList(materials, "Id", "Name");
                var model = new CourseMaterialsView
                {
                    CourseId = course.Id,
                    CourseName = course.Name,
                    Materials = selectMaterialsList.ToList()
                };

                for (int i = 0; i < materials.Count; i++)
                {
                    if (course.Materials.Contains(materials[i]))
                    {
                        model.Materials[i].Selected = true;
                    }
                }

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterials(CourseMaterialsView? courseMaterials)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(courseMaterials.CourseId);
            if (course != null)
            {
                var materials = await _materialEditService.GetMaterials();
                course.Materials.Clear();
                foreach (var material in materials)
                {
                    if (courseMaterials.MaterialsId.Contains(material.Id))
                    {
                        course.Materials.Add(material);
                    }
                }

                await _courseEditService.UpdateCourse(course);
            }

            return RedirectToAction("Courses");
        }

        public async Task<IActionResult> AddSkills(int? id)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(id ?? 0);
            if (course != null)
            {
                var skills = await _skillEditService.GetSkills();
                var selectSkillsList = new SelectList(skills, "Id", "Title");
                var model = new CourseSkillView
                {
                    CourseId = course.Id,
                    CourseName = course.Name,
                    Skills = selectSkillsList.ToList()
                };

                for (int i = 0; i < skills.Count; i++)
                {
                    if (course.Skills.Contains(skills[i]))
                    {
                        model.Skills[i].Selected = true;
                    }
                }

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddSkills(CourseSkillView? courseMaterials)
        {
            CourseView? course = await _courseEditService.GetByIdCourse(courseMaterials.CourseId);
            if (course != null)
            {
                var skills = await _skillEditService.GetSkills();
                course.Skills.Clear();
                foreach (var skill in skills)
                {
                    if (courseMaterials.SkillId.Contains(skill.Id))
                    {
                        course.Skills.Add(skill);
                    }
                }

                await _courseEditService.UpdateCourse(course);
            }

            return RedirectToAction("Courses");
        }
    }
}
