using EducationPortal.Domain.Entities.Materials;
using FluentValidation;

namespace EducationPortal.Application.Commands.Validation
{
    internal class CreateArticleValidation : AbstractValidator<ArticleMaterial>
    {
        public CreateArticleValidation()
        {
            RuleFor(u => u.Name)
               .NotEmpty();
        }
    }
}
