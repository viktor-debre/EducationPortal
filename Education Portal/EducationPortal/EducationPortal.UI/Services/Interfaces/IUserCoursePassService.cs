namespace EducationPortal.UI.Services.Interfaces
{
    public interface IUserCoursePassService
    {
        public Task<List<CourseView>> AvailableCourses(string userName);

        public Task TakeCourse(int? courseId, string userName);

        public Task<List<CourseView>> StartedCourses(string userName);

        public Task<List<UserCourseView>> StartedCoursesGetStatusInfo(string userName);

        public Task PassMaterial(int? courseId, string? materialName, string userName);

        public Task<List<CourseView>> PassedCourses(string userName);

        public Task<CourseView> GetCourseToPass(int? courseId);

        public Task<List<MaterialView>> PassedMaterials(int? courseId, string userName);
    }
}
