using EducationPortal.Domain.Helpers.Specification;

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
            var skill = GetSkillByTitle(title);
            _skillRepository.Remove(skill);
        }

        public Skill? GetSkillByTitle(string title)
        {
            var skillNameSpecification = new SpecificationBase<Skill>(x => x.Title == title);
            return _skillRepository.Find(skillNameSpecification).FirstOrDefault();
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
            var skillToUpdate = _skillRepository.FindById(skill.Id);
            skillToUpdate.Title = updatedSkill.Title;
            _skillRepository.Update(skillToUpdate);
        }
    }
}
