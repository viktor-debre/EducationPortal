using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository.Concrete
{
    internal class UserCourseRepository : IUserCourseRepository
    {
        private PortalContext _context;
        private readonly MapperForEntities _mapper;

        public UserCourseRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public List<UserCourse> Find()
        {
            List<UserCourse> userCourses = new List<UserCourse>();
            var dbUserCourses = _context.UserCourses.ToList();
            foreach (var userCourse in dbUserCourses)
            {
                userCourses.Add(_mapper.MapToDomainUserCourse(userCourse));
            }

            return userCourses;
        }

        public UserCourse FindById(int userId, int courseId)
        {
            return _mapper.MapToDomainUserCourse(_context.UserCourses.Find(userId, courseId));
        }

        public void Update(UserCourse userCourse)
        {
            _context.Entry(_mapper.MapToDbUserCourse(userCourse)).State = EntityState.Modified;
            Save();
        }

        public void Add(UserCourse userCourse)
        {
            _context.Add(_mapper.MapToDbUserCourse(userCourse));
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
