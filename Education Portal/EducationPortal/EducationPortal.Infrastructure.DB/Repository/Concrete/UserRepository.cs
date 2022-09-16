using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Domain.Helpers.Specification;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository.Concrete
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

        public async Task Remove(User user)
        {
            _context.Users.Remove(_mapper.MapToDbUser(user));
            SaveAsync();
        }

        public async Task<List<User>> Find(ISpecification<User> specification = null)
        {
            List<User> users = new List<User>();
            var dbUsers = _context.Users
                .Include(x => x.Materials)
                .Include(x => x.Skills)
                .Include(x => x.Courses).ThenInclude(x => x.Materials)
                .Include(x => x.Courses).ThenInclude(x => x.Skills)
                .ToList();
            foreach (var user in dbUsers)
            {
                users.Add(_mapper.MapToDomainUser(user));
            }

            List<User> result;
            if (specification != null)
            {
                result = users.AsQueryable().Where(specification.Criteria).ToList();
            }
            else
            {
                result = users;
            }

            return result;
        }

        public async Task<User?> FindById(int id)
        {
            return _mapper.MapToDomainUser(await _context.Users.FindAsync(id));
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(_mapper.MapToDbUser(user));
            await SaveAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(_mapper.MapToDbUser(user)).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
