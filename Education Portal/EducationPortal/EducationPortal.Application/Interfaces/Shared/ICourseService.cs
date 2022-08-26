namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ICourseService
    {
        public List<Course> GetCourses();

        public void SetCourse(Course book);

        public void UpdateCourse(Course course, Course updatedCourse);

        public void DeleteCourse(string name);
    }
}
