using EducationPortal.Domain.Repository;

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
            var id = _skillRepository.GetSkill().FirstOrDefault(x => x.Title == title).Id;
            _skillRepository.DeleteSkill(id);
        }

        public List<Skill> GetSkills()
        {
            return _skillRepository.GetSkill();
        }

        public void SetSkill(Skill skill)
        {
            _skillRepository.SetSkill(skill);
        }

        public void UpdateSkill(string title, Skill updatedSkill)
        {
            var id = _skillRepository.GetSkill().FirstOrDefault(x => x.Title == title).Id;
            _skillRepository.UpdateSkill(id, updatedSkill);
        }
    }
}
