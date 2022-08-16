using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly PortalContext _context;

        public CourseRepository(PortalContext context)
        {
            _context = context;
        }

        public void AddMaterial(string name, Material material)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Name == name);
            if (course != null)
            {
                course.Materials.Add(material.MapMaterialToDbMaterial());
                Save();
            }
        }

        public void DeleteCourse(string name)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Name == name);
            if (course != null)
            {
                _context.Courses.Remove(course);
                Save();
            }
        }

        public Course? GetCourceById(int id)
        {
            return (Course?)_context.Courses.Find(id).MapDbCourseToCourse();
        }

        public List<Course> GetCources()
        {
            List<Course> courses = new List<Course>();
            foreach (var course in _context.Courses)
            {
                courses.Add(course.MapDbCourseToCourse());
            }

            return courses;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetCourse(Course cource)
        {
            _context.Add(cource.MapCourseToDbCourse());
            Save();
        }

        public void UpdateCourse(string name, Course updatedMaterial)
        {
            _context.Entry(updatedMaterial.MapCourseToDbCourse()).State = EntityState.Modified;
            Save();
        }
    }
}
