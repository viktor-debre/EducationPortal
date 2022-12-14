using FluentValidation;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateCourseValidation : AbstractValidator<Course>
    {
        public CreateCourseValidation()
        {
            RuleFor(u => u.Name)
               .NotEmpty();
        }
    }
}