using FluentValidation;
using System.Text.RegularExpressions;

namespace EducationPortal.Application.Commands
{
    internal class CreateUserValidation : AbstractValidator<User>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.Name)
                .NotEmpty();

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(4)
                .Must(IsValidPassword);
        }

        private bool IsValidPassword(string password)
        {
            // TODO: make validation for password

            //Regex validateGuidRegex = new Regex("^(?=.*?[0-9])$");
            //if (!validateGuidRegex.IsMatch(password))
            //{
            //    return false;
            //}
            return true;
        }
    }
}
