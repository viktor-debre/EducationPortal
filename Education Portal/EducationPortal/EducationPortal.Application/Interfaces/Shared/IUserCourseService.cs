namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserCourseService
    {
        public List<Course> GetAvailableCourses();

        public List<UserCourse> GetStartedCourses(int userId);

        public List<UserCourse> GetPassedCourses(int userId);

        public void TakeCourse(Course course, int userId);

        public bool PassMaterial(Course course, string nameMaterial, int userId);
    }
}
