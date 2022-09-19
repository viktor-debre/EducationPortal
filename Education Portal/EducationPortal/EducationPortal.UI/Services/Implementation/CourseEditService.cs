using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class CourseEditService : ICourseEditService
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseEditService(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
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
            await _courseService.DeleteCourse(course.Name);
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
    }
}
