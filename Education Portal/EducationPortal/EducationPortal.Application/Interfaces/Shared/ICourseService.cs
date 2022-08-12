using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ICourseService
    {
        public List<Course> GetCourses();

        public void SetCourse(Course book);

        public void UpdateCourse(string name, Course updatedCourse);

        public bool DeleteCourse(string name);

        public void AddMaterial(string name, Material material);
    }
}
