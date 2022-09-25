namespace EducationPortal.UI.Services.Interfaces
{
    public interface IPassCourseService
    {
        public Task<UserCourseView> GetUserCoursesById(int userId, int courseId);

        public Task<List<CourseView>> GetAvailableCourses(int userId);

        public Task<List<UserCourseView>> GetStartedCourses(int userId);

        public Task<List<UserCourseView>> GetPassedCourses(int userId);

        public Task TakeCourse(CourseView course, int userId);

        public Task<bool> PassMaterial(CourseView course, string nameMaterial, int userId);
    }
}
