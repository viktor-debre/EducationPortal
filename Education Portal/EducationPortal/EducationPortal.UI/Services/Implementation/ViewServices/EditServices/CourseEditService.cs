using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;
using EducationPortal.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPortal.UI.Services.Implementation
{
    public class CourseEditService : ICourseEditService
    {
        //application layer services
        private readonly ICourseService _courseService;
        //ui layer services
        private readonly IMaterialEditService _materialEditService;
        private readonly ISkillEditService _skillEditService;
        private readonly IMapper _mapper;

        public CourseEditService(
            ICourseService courseService,
            IMaterialEditService materialEditService,
            ISkillEditService skillEditService,
            IMapper mapper)
        {
            _courseService = courseService;
            _materialEditService = materialEditService;
            _skillEditService = skillEditService;
            _mapper = mapper;
        }

        public async Task<List<CourseView>> GetCourses()
        {
            List<CourseView> courses = new List<CourseView>();
            foreach (var course in await _courseService.GetCourses())
            {
                courses.Add(_mapper.MapCourseToViewModel(course));
            }

            return courses;
        }

        public async Task SetCourse(CourseView course)
        {
            await _courseService.SetCourse(_mapper.MapCourseToDomainModel(course));
        }

        public async Task RemoveCourse(CourseView course)
        {
            await _courseService.DeleteCourse(_mapper.MapCourseToDomainModel(course));
        }

        public async Task UpdateCourse(CourseView course)
        {
            var updatedSkill = _mapper.MapCourseToDomainModel(course);
            await _courseService.UpdateCourse(updatedSkill, updatedSkill);
        }

        public async Task<CourseView>? GetByIdCourse(int id)
        {
            var course = await _courseService.GetCourseById(id);
            return course is not null ? _mapper.MapCourseToViewModel(course) : null;
        }

        public async Task AddMaterialsInCourse(CourseMaterialsView? courseMaterials)
        {
            CourseView? course = await GetByIdCourse(courseMaterials.CourseId);
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

                await UpdateCourse(course);
            }
        }

        public async Task AddSkillsInCourse(CourseSkillView? courseMaterials)
        {
            CourseView? course = await GetByIdCourse(courseMaterials.CourseId);
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

                await UpdateCourse(course);
            }
        }
    }
}
