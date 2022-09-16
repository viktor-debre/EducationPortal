using EducationPortal.Application.Commands.CreateEntity;
using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Application.Services
{
    internal class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;

        private readonly CreateSkill _createSkill;

        public SkillService(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
            _createSkill = new CreateSkill(skillRepository);
        }

        public async Task DeleteSkill(string title)
        {
            var skill = await GetSkillByTitle(title);
            await _skillRepository.Remove(skill);
        }

        public async Task<Skill?> GetSkillByTitle(string title)
        {
            var skillNameSpecification = new SpecificationBase<Skill>(x => x.Title == title);
            var item = await _skillRepository.Find(skillNameSpecification);
            return item.FirstOrDefault();
        }

        public async Task<Skill?> GetSkillById(int id)
        {
            return await _skillRepository.FindById(id);
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _skillRepository.Find();
        }

        public async Task SetSkill(Skill skill)
        {
            await _createSkill.TryCreateSkill(skill);
        }

        public async Task UpdateSkill(Skill skill)
        {
            var skillToUpdate = await _skillRepository.FindById(skill.Id);
            skillToUpdate.Title = skill.Title;
            await _skillRepository.Update(skillToUpdate);
        }
    }
}
