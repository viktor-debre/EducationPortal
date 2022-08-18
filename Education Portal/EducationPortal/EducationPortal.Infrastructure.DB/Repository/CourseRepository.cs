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
                _context.Update(course);
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
            var dbCourses = _context.Courses.Include(x => x.Materials).ToList();
            foreach (var course in dbCourses)
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
            DbCourse dbCourse = cource.MapCourseToDbCourse();

            if (dbCourse != null)
            {
                dbCourse.Materials = new List<DbMaterial>();
                foreach (var material in cource.Materials)
                {
                    dbCourse.Materials.Add(_context.Materials.Find(material.Id));
                }

                _context.Courses.Add(dbCourse);
                Save();
            }
        }

        public void UpdateCourse(string name, Course updatedCourse)
        {
            DbCourse course = _context.Courses.FirstOrDefault(x => x.Name == name);

            if (course != null)
            {
                course.Name = updatedCourse.Name;
                course.Description = updatedCourse.Description;
                course.Materials = new List<DbMaterial>();
                foreach (var material in updatedCourse.Materials)
                {
                    course.Materials.Add(_context.Materials.Find(material.Id));
                }

                _context.Update(course);
                Save();
            }
        }
    }
}
