namespace EducationPortal.Application.Services
{
    internal class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public void DeleteSkill(string title)
        {
            var skill = _skillRepository.Find().FirstOrDefault(x => x.Title == title);
            _skillRepository.Remove(skill);
        }

        public List<Skill> GetSkills()
        {
            return _skillRepository.Find();
        }

        public void SetSkill(Skill skill)
        {
            _skillRepository.Add(skill);
        }

        public void UpdateSkill(Skill skill, Skill updatedSkill)
        {
            var skillToUpdate = _skillRepository.Find().FirstOrDefault(a => a.Id == skill.Id);
            skillToUpdate.Title = updatedSkill.Title;
            _skillRepository.Update(skillToUpdate);
        }
    }
}
