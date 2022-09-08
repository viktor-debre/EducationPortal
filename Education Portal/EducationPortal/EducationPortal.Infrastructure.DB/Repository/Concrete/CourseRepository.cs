using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository.Concrete
{
    internal class CourseRepository : IRepository<Course>
    {
        private readonly PortalContext _context;
        private readonly MapperForEntities _mapper;

        public CourseRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void Remove(Course course)
        {
            _context.Courses.Remove((DbCourse)_mapper.MapToDbEntity(course));
            Save();
        }

        public Course? FindById(int id)
        {
            return _mapper.MapToDomainCourse(_context.Courses.Find(id));
        }

        public List<Course> Find()
        {
            List<Course> courses = new List<Course>();
            var dbCourses = _context.Courses.Include(x => x.Materials).Include(x => x.Skills).ToList();
            foreach (var course in dbCourses)
            {
                courses.Add(_mapper.MapToDomainCourse(course));
            }

            return courses;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Add(Course course)
        {
            _context.Add((DbCourse)_mapper.MapToDbEntity(course));
            Save();
        }

        public void Update(Course course)
        {
            _context.Entry((DbCourse)_mapper.MapToDbEntity(course)).State = EntityState.Modified;
            Save();
        }
    }
}
