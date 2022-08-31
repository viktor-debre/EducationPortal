using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository.Concrete
{
    internal class UserSkillRepository : IUserSkillRepository
    {
        private PortalContext _context;
        private readonly MapperForEntities _mapper;

        public UserSkillRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public List<UserSkill> Find()
        {
            List<UserSkill> users = new List<UserSkill>();
            var dbUsersSkills = _context.UserSkills.ToList();
            foreach (var userSkill in dbUsersSkills)
            {
                users.Add(_mapper.MapToDomainUserSkill(userSkill));
            }

            return users;
        }

        public void Update(UserSkill userSkill)
        {
            _context.Entry(_mapper.MapToDbUserSkill(userSkill)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserSkill FindById(int userId, int skillId)
        {
            return _mapper.MapToDomainUserSkill(_context.UserSkills.Find(userId, skillId));
        }
    }
}
