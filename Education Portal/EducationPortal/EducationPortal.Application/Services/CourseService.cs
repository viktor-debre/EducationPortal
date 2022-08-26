namespace EducationPortal.Application.Services
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void DeleteCourse(string name)
        {
            var course = _courseRepository.GetCources().FirstOrDefault(x => x.Name == name);
            if (course != null)
            {
                _courseRepository.DeleteCourse(course);
            }
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.GetCources();
        }

        public void SetCourse(Course course)
        {
            _courseRepository.SetCourse(course);
        }

        public void UpdateCourse(Course course, Course updatedCourse)
        {
            var courseToUpdate = _courseRepository.GetCources().FirstOrDefault(a => a.Id == course.Id);
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
            _courseRepository.UpdateCourse(courseToUpdate);
        }
    }
}
