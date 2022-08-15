using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetCources();

        public Course? GetCourceById(int id);

        public void SetCourse(Course cource);

        public void UpdateCourse(string name, Course updatedMaterial);

        public void DeleteCourse(string name);

        public void AddMaterial(string name, Material material);

        public void Save();
    }
}
