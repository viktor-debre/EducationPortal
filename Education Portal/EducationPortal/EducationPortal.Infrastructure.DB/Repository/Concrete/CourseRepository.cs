using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Domain.Helpers.Specification;
using EducationPortal.Infrastructure.DB.Mapping;
using Microsoft.EntityFrameworkCore;

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
            var courseInDb = await _context.Courses.FindAsync(course.Id);
            _context.Courses.Remove(courseInDb);
            await SaveAsync();
        }

        public async Task<Course?> FindById(int id)
        {
            var course = await _context.Courses.Include(x => x.Materials).Include(x => x.Skills).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.MapToDomainCourse(course);
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
                result = courses.AsQueryable().Where(specification.Criteria).ToList();
            }
            else
            {
                result = courses;
            }

            return result;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
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
