using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Domain.Helpers.Specification;
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

        public async Task Remove(Course course)
        {
            _context.Courses.Remove((DbCourse)await _mapper.MapToDbEntity(course));
            await SaveAsync();
        }

        public async Task<Course?> FindById(int id)
        {
            return _mapper.MapToDomainCourse(await _context.Courses.FindAsync(id));
        }

        public async Task<List<Course>> Find(ISpecification<Course> specification = null)
        {
            List<Course> courses = new List<Course>();
            var dbCourses = await _context.Courses.Include(x => x.Materials).Include(x => x.Skills).ToListAsync();
            foreach (var course in dbCourses)
            {
                courses.Add(_mapper.MapToDomainCourse(course));
            }

            List<Course> result;
            if (specification != null)
            {
                result = await courses.AsQueryable().Where(specification.Criteria).ToListAsync();
            }
            else
            {
                result = courses;
            }

            return result;
        }

        public async Task SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task Add(Course course)
        {
            await _context.AddAsync((DbCourse)await _mapper.MapToDbEntity(course));
            await SaveAsync();
        }

        public async Task Update(Course course)
        {
            _context.Entry((DbCourse)await _mapper.MapToDbEntity(course)).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}
