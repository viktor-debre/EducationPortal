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
            var id = _courseRepository.GetCources().FirstOrDefault(x => x.Name == name).Id;
            if (id != null)
            {
                _courseRepository.DeleteCourse(id);
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

        public void UpdateCourse(string name, Course updatedCourse)
        {
            _courseRepository.UpdateCourse(name, updatedCourse);
        }
    }
}
