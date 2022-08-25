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

            var checkArticle = _articleRepository.GetArticle().FirstOrDefault(x => x.Name == article.Name);
            if (checkArticle != null)
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
