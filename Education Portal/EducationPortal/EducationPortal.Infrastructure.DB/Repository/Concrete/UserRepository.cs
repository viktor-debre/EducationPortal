using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class UserRepository : IUserRepository
    {
        private PortalContext _context;
        private readonly MapperForEntities _mapper;

        public UserRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(_mapper.MapToDbUser(user));
            Save();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            foreach (var user in _context.Users)
            {
                users.Add(_mapper.MapToDomainUser(user));
            }

            return users;
        }

        public User? GetUserById(int id)
        {
            return _mapper.MapToDomainUser(_context.Users.Find(id));
        }

        public void SetUser(User user)
        {
            _context.Add(_mapper.MapToDbUser(user));
            Save();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(_mapper.MapToDbUser(user)).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
