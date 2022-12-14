namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ICourseService
    {
        public Task<List<Course>> GetCourses();

        public Task<Course?> GetCourseByName(string name);

        public Task SetCourse(Course book);

        public Task UpdateCourse(Course course, Course updatedCourse);

        public Task DeleteCourse(Course course);

        public Task<Course?> GetCourseById(int id);
    }
}
