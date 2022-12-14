namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserCourseService
    {
        public Task<UserCourse> GetUserCoursesById(int userId, int courseId);

        public Task<List<Course>> GetAvailableCourses(int userId);

        public Task<List<UserCourse>> GetStartedCourses(int userId);

        public Task<List<UserCourse>> GetPassedCourses(int userId);

        public Task TakeCourse(Course course, int userId);

        public Task<bool> PassMaterial(Course course, string nameMaterial, int userId);
    }
}
