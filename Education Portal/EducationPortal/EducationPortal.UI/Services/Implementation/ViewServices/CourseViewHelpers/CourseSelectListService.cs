using EducationPortal.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPortal.UI.Services.Implementation
{
    public class CourseSelectListService : ICourseSelectListsService
    {
        private readonly ICourseEditService _courseEditService;
        private readonly IMaterialEditService _materialEditService;
        private readonly ISkillEditService _skillEditService;

        public CourseSelectListService(
            ICourseEditService courseEditService,
            IMaterialEditService materialEditService,
            ISkillEditService skillEditService
        )
        {
            _courseEditService = courseEditService;
            _materialEditService = materialEditService;
            _skillEditService = skillEditService;
        }

        public async Task<CourseMaterialsView> GetAllMaterialsSelectList(int courseId)
        {
            CourseMaterialsView model = new CourseMaterialsView();
            CourseView? course = await _courseEditService.GetByIdCourse(courseId);
            if (course != null)
            {
                var materials = await _materialEditService.GetMaterials();
                var selectMaterialsList = new SelectList(materials, "Id", "Name");
                model.CourseId = course.Id;
                model.CourseName = course.Name;
                model.Materials = selectMaterialsList.ToList();
                for (int i = 0; i < materials.Count; i++)
                {
                    if (course.Materials.Contains(materials[i]))
                    {
                        model.Materials[i].Selected = true;
                    }
                }
            }

            return model;
        }

        public async Task<CourseSkillView> GetAllSkillsSelectList(int courseId)
        {
            var model = new CourseSkillView();
            CourseView? course = await _courseEditService.GetByIdCourse(courseId);
            if (course != null)
            {
                var skills = await _skillEditService.GetSkills();
                var selectSkillsList = new SelectList(skills, "Id", "Title");
                model.CourseId = course.Id;
                model.CourseName = course.Name;
                model.Skills = selectSkillsList.ToList();
                for (int i = 0; i < skills.Count; i++)
                {
                    if (course.Skills.Contains(skills[i]))
                    {
                        model.Skills[i].Selected = true;
                    }
                }
            }

            return model;
        }
    }
}
