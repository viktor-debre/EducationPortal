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
    }
}
