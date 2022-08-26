namespace EducationPortal.Domain.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetCources();

        public Course? GetCourceById(int id);

        public void SetCourse(Course cource);

        public void UpdateCourse(Course cource);

        public void DeleteCourse(Course cource);

        public void Save();
    }
}
