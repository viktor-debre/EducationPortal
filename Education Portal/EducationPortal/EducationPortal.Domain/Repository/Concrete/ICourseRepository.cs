namespace EducationPortal.Domain.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetCources();

        public Course? GetCourceById(int id);

        public void SetCourse(Course cource);

        public void UpdateCourse(string name, Course updatedMaterial);

        public void DeleteCourse(int id);

        public void Save();
    }
}
