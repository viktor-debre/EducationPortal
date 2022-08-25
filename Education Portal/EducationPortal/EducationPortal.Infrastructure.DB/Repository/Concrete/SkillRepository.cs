using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class SkillRepository : ISkillRepository
    {
        private readonly PortalContext _context;
        private readonly MapToDbModels _mapper;

        public SkillRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapToDbModels(context);
        }

        public void DeleteSkill(Skill skill)
        {
            _context.Skills.Remove(_mapper.MapToDbSkill(skill));
            Save();
        }

        public List<Skill> GetSkills()
        {
            List<Skill> skills = new List<Skill>();
            foreach (var skill in _context.Skills)
            {
                skills.Add(skill.MapDbSkillToSkill());
            }

            return skills;
        }

        public void SetSkill(Skill skill)
        {
            _context.Skills.Add(_mapper.MapToDbSkill(skill));
            Save();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Entry(_mapper.MapToDbSkill(skill)).State = EntityState.Modified;
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