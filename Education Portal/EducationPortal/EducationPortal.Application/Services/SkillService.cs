namespace EducationPortal.Application.Services
{
    internal class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public void DeleteSkill(string title)
        {
            var skill = _skillRepository.GetSkills().FirstOrDefault(x => x.Title == title);
            _skillRepository.DeleteSkill(skill);
        }

        public List<Skill> GetSkills()
        {
            return _skillRepository.GetSkills();
        }

        public void SetSkill(Skill skill)
        {
            _skillRepository.SetSkill(skill);
        }

        public void UpdateSkill(Skill skill, Skill updatedSkill)
        {
            var skillToUpdate = _skillRepository.GetSkills().FirstOrDefault(a => a.Id == skill.Id);
            skillToUpdate.Title = updatedSkill.Title;
            _skillRepository.UpdateSkill(skillToUpdate);
        }
    }
}
