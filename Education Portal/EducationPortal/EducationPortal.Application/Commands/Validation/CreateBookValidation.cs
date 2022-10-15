using FluentValidation;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateBookValidation : AbstractValidator<BookMaterial>
    {
        public CreateBookValidation()
        {
             RuleFor(u => u.Name)
                .NotEmpty();
        }
    }
}
