using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
{
    internal class CreateSkill
    {
        private readonly IRepository<Skill> _skillRepository;

        public CreateSkill(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<bool> TryCreateSkill(Skill skill)
        {
            CreateSkillValidation validations = new CreateSkillValidation();
            ValidationResult validationResult = validations.Validate(skill);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var skillNameSpecification = new SpecificationBase<Skill>(x => x.Title == skill.Title);
            var checkSkill = await _skillRepository.Find(skillNameSpecification);
            if (checkSkill.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                await _skillRepository.Add(skill);
                return true;
            }
        }
    }
}
