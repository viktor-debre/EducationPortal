using FluentValidation;

namespace EducationPortal.Application.Commands
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
