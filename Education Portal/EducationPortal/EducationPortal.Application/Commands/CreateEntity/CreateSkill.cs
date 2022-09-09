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

        public bool TryCreateSkill(Skill skill)
        {
            CreateSkillValidation validations = new CreateSkillValidation();
            ValidationResult validationResult = validations.Validate(skill);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var skillNameSpecification = new SpecificationBase<Skill>(x => x.Title == skill.Title);
            var checkSkill = _skillRepository.Find(skillNameSpecification).FirstOrDefault();
            if (checkSkill != null)
            {
                return false;
            }
            else
            {
                _skillRepository.Add(skill);
                return true;
            }
        }
    }
}
