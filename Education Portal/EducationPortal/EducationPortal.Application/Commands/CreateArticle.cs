using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateArticle
    {
        private readonly IMaterialRepository _materialRepository;

        public CreateArticle(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public bool TryCreateArticle(ArticleMaterial article)
        {
            CreateArticleValidation validations = new CreateArticleValidation();
            ValidationResult validationResult = validations.Validate(article);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _materialRepository.GetMaterials();
            Material? existingMaterial = _materialRepository.GetMaterialByName(article.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _materialRepository.SetMaterial(article);
                return true;
            }
        }
    }
}
