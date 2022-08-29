using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private PortalContext _context;
        private readonly MapperForEntities _mapper;

        public UserRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(_mapper.MapToDbUser(user));
            Save();
        }

        public List<User> Find()
        {
            List<User> users = new List<User>();
            var dbUsers = _context.Users.Include(x => x.Materials).Include(x => x.Skills).ToList();
            foreach (var user in dbUsers)
            {
                users.Add(_mapper.MapToDomainUser(user));
            }

            return users;
        }

        public User? FindById(int id)
        {
            return _mapper.MapToDomainUser(_context.Users.Find(id));
        }

        public void Add(User user)
        {
            _context.Add(_mapper.MapToDbUser(user));
            Save();
        }

        public void Update(User user)
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
