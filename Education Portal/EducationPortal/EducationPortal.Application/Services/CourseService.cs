namespace EducationPortal.Application.Services
{
    internal class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void DeleteCourse(string name)
        {
            var course = _courseRepository.Find().FirstOrDefault(x => x.Name == name);
            if (course != null)
            {
                _courseRepository.Remove(course);
            }
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.Find();
        }

        public void SetCourse(Course course)
        {
            _courseRepository.Add(course);
        }

        public void UpdateCourse(Course course, Course updatedCourse)
        {
            var courseToUpdate = _courseRepository.Find().FirstOrDefault(a => a.Id == course.Id);
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
