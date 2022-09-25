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

        public async Task DeleteCourse(Course course)
        {
            if (course != null)
            {
                await _courseRepository.Remove(course);
            }
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _courseRepository.FindById(id) ?? null;
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _courseRepository.Find();
        }

        public async Task<Course?> GetCourseByName(string name)
        {
            var courseNameSpecification = new SpecificationBase<Course>(x => x.Name == name);
            var item = await _courseRepository.Find(courseNameSpecification);
            return item.FirstOrDefault();
        }

        public async Task SetCourse(Course course)
        {
            await _createCourse.TryCreateCorse(course);
        }

        public async Task UpdateCourse(Course course, Course updatedCourse)
        {
            var courseToUpdate = await _courseRepository.FindById(course.Id);
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
            await _courseRepository.Update(courseToUpdate);
        }
    }
}
