using EducationPortal.Domain.Entities.Materials;
using FluentValidation;

namespace EducationPortal.Application.Commands
{
    internal class CreateBookValidation : AbstractValidator<BookMaterial>
    {
        public CreateBookValidation()
        {
             RuleFor(u => u.Name)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
