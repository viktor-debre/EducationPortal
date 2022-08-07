using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateBook
    {
        private readonly IMaterialRepository _materialRepository;

        public CreateBook(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public bool TryCreateBook(BookMaterial book)
        {
            CreateBookValidation validations = new CreateBookValidation();
            ValidationResult validationResult = validations.Validate(book);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _materialRepository.GetMaterials();
            Material? existingMaterial = _materialRepository.GetMaterialByName(book.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _materialRepository.SetMaterial(book);
                return true;
            }
        }
    }
}
