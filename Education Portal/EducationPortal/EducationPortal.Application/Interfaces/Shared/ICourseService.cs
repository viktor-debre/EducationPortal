namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ICourseService
    {
        public List<Course> GetCourses();

        public Course? GetCourseByName(string name);

        public void SetCourse(Course book);

        public void UpdateCourse(Course course, Course updatedCourse);

        public void DeleteCourse(string name);

        public Course? GetCourseById(int id);
    }
}
