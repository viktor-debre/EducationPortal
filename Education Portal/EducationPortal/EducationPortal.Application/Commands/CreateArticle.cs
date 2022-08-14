using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateArticle
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticle(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public bool TryCreateArticle(ArticleMaterial article)
        {
            CreateArticleValidation validations = new CreateArticleValidation();
            ValidationResult validationResult = validations.Validate(article);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _articleRepository.GetArticle();
            Material? existingMaterial = _articleRepository.GetArticleByName(article.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _articleRepository.SetArticle(article);
                return true;
            }
        }
    }
}
