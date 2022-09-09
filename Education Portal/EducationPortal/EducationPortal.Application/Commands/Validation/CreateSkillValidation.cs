using FluentValidation;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateSkillValidation : AbstractValidator<Skill>
    {
        public CreateSkillValidation()
        {
            RuleFor(u => u.Title)
               .NotEmpty();
        }
    }
}
