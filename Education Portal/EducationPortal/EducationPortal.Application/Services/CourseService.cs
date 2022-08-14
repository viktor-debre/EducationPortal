using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Application.Services
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AddMaterial(string name, Material material)
        {
            _courseRepository.AddMaterial(name, material);
        }

        public bool DeleteCourse(string name)
        {
            return _courseRepository.DeleteCourse(name);
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.GetCources();
        }

        public void SetCourse(Course book)
        {
            _courseRepository.SetCourse(book);
        }

        public void UpdateCourse(string name, Course updatedCourse)
        {
            _courseRepository.UpdateCourse(name, updatedCourse);
        }
    }
}
