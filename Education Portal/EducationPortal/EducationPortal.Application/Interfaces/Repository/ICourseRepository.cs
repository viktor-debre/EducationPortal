using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface ICourseRepository
    {
        public List<Course> Courses { get; }

        public List<Course> GetCources();

        public Course? GetCourceByName(string name);

        public void SetCourse(Course cource);

        public void UpdateCourse(string name, Course updatedMaterial);

        public bool DeleteCourse(string name);

        public void AddMaterial(string name, Material material);
    }
}
