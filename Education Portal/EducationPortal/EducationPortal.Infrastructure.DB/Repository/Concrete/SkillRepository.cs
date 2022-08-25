using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class SkillRepository : ISkillRepository
    {
        private readonly PortalContext _context;
        private readonly MapperForEntities _mapper;

        public SkillRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void DeleteSkill(Skill skill)
        {
            _context.Skills.Remove((DbSkill)_mapper.MapToDbEntity(skill));
            Save();
        }

        public List<Skill> GetSkills()
        {
            List<Skill> skills = new List<Skill>();
            foreach (var skill in _context.Skills)
            {
                skills.Add(skill.MapToDomainSkill());
            }

            return skills;
        }

        public void SetSkill(Skill skill)
        {
            _context.Skills.Add((DbSkill)_mapper.MapToDbEntity(skill));
            Save();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Entry((DbSkill)_mapper.MapToDbEntity(skill)).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private DbSkill? GetSkillById(int id)
        {
            return _context.Skills.Find(id);
        }
    }
}