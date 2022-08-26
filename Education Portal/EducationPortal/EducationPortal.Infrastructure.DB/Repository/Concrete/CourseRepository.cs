using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly PortalContext _context;
        private readonly MapperForEntities _mapper;

        public CourseRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove((DbCourse)_mapper.MapToDbEntity(course));
            Save();
        }

        public Course? GetCourceById(int id)
        {
            return (Course?)_context.Courses.Find(id).MapToDomainCourse();
        }

        public List<Course> GetCources()
        {
            List<Course> courses = new List<Course>();
            var dbCourses = _context.Courses.Include(x => x.Materials).Include(x => x.Skills).ToList();
            foreach (var course in dbCourses)
            {
                courses.Add(course.MapToDomainCourse());
            }

            return courses;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetCourse(Course course)
        {
            _context.Add((DbCourse)_mapper.MapToDbEntity(course));
            Save();
        }

        public void UpdateCourse(Course course)
        {
            _context.Entry((DbCourse)_mapper.MapToDbEntity(course)).State = EntityState.Modified;
            Save();
        }
    }
}
