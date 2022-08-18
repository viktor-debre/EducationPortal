using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class SkillRepository : ISkillRepository
    {
        private readonly PortalContext _context;

        public SkillRepository(PortalContext context)
        {
            _context = context;
        }

        public Skill? GetSkillById(int id)
        {
            return _context.Skills.Find(id).MapDbSkillToSkill();
        }

        public void DeleteSkill(int id)
        {
            var skill = GetSkillById(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill.MapSkillToDbSkill());
                Save();
            }
        }

        public List<Skill> GetSkill()
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
            _context.Add(skill.MapSkillToDbSkill());
            Save();
        }

        public void UpdateSkill(int id, Skill updatedSkill)
        {
            DbSkill skill = GetSkillById(id).MapSkillToDbSkill();
            if (skill != null)
            {
                _context.Update(skill);
                skill.Title = updatedSkill.Title;
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}