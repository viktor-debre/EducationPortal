using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
{
    internal class CreateArticle
    {
        private readonly IRepository<ArticleMaterial> _articleRepository;

        public CreateArticle(IRepository<ArticleMaterial> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<bool> TryCreateArticle(ArticleMaterial article)
        {
            CreateArticleValidation validations = new CreateArticleValidation();
            ValidationResult validationResult = validations.Validate(article);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var articleNameSpecification = new SpecificationBase<ArticleMaterial>(x => x.Name == article.Name);
            var checkArticle = await _articleRepository.Find(articleNameSpecification);
            if (checkArticle.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                await _articleRepository.Add(article);
                return true;
            }
        }
    }
}
