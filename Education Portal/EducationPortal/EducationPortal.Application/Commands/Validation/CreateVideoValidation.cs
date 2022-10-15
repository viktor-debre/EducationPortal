using FluentValidation;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateVideoValidation : AbstractValidator<VideoMaterial>
    {
        public CreateVideoValidation()
        {
            RuleFor(u => u.Name)
               .NotEmpty();
        }
    }
}
