using EducationPortal.Application.Commands.CreateEntity;
using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Application.Services
{
    internal class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        private readonly CreateCourse _createCourse;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
            _createCourse = new CreateCourse(courseRepository);
        }

        public void DeleteCourse(string name)
        {
            var course = GetCourseByName(name);
            if (course != null)
            {
                _courseRepository.Remove(course);
            }
        }

        public Course? GetCourseById(int id)
        {
            return _courseRepository.FindById(id);
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.Find();
        }

        public Course? GetCourseByName(string name)
        {
            var courseNameSpecification = new SpecificationBase<Course>(x => x.Name == name);
            return _courseRepository.Find(courseNameSpecification).FirstOrDefault();
        }

        public void SetCourse(Course course)
        {
            _createCourse.TryCreateCorse(course);
        }

        public void UpdateCourse(Course course, Course updatedCourse)
        {
            var courseToUpdate = _courseRepository.FindById(course.Id);
            courseToUpdate.Name = updatedCourse.Name;
            courseToUpdate.Description = updatedCourse.Description;
            List<Material> materials = new List<Material>();
            foreach (var material in updatedCourse.Materials)
            {
                materials.Add(material);
            }

            courseToUpdate.Materials = materials;
            List<Skill> skills = new List<Skill>();
            foreach (var skill in updatedCourse.Skills)
            {
                skills.Add(skill);
            }

            courseToUpdate.Skills = skills;
            _courseRepository.Update(courseToUpdate);
        }
    }
}
