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
            _context.Users.Remove(await _mapper.MapToDbUser(user));
            await SaveAsync();
        }

        public async Task<List<User>> Find(ISpecification<User> specification = null)
        {
            List<User> users = new List<User>();
            var dbUsers = await _context.Users
                .Include(x => x.Materials)
                .Include(x => x.Skills)
                .Include(x => x.Courses).ThenInclude(x => x.Materials)
                .Include(x => x.Courses).ThenInclude(x => x.Skills)
                .ToListAsync();
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
            var users = await _context.Users
                .Include(x => x.Materials)
                .Include(x => x.Skills)
                .Include(x => x.Courses).ThenInclude(x => x.Materials)
                .Include(x => x.Courses).ThenInclude(x => x.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.MapToDomainUser(users);
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(await _mapper.MapToDbUser(user));
            await SaveAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(await _mapper.MapToDbUser(user)).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
