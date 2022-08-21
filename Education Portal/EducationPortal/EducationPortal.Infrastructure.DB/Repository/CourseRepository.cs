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
            var dbCourses = _context.Courses.Include(x => x.Materials).Include(x => x.Skills).ToList();
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

        public void SetCourse(Course course)
        {
            DbCourse dbCourse = course.MapCourseToDbCourse();

            if (dbCourse != null)
            {
                dbCourse.Materials = new List<DbMaterial>();
                foreach (var material in course.Materials)
                {
                    dbCourse.Materials.Add(_context.Materials.Find(material.Id));
                }

                dbCourse.Skills = new List<DbSkill>();
                foreach (var skill in course.Skills)
                {
                    dbCourse.Skills.Add(_context.Skills.Find(skill.Id));
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

                course.Skills = new List<DbSkill>();
                foreach (var skill in updatedCourse.Skills)
                {
                    course.Skills.Add(_context.Skills.Find(skill.Id));
                }

                _context.Update(course);
                Save();
            }
        }
    }
}
