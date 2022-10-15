using FluentValidation;
using System.Text.RegularExpressions;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateUserValidation : AbstractValidator<User>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.Name)
                .NotEmpty();

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(4);
        }
    }
}
