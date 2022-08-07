using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateVideo
    {
        private readonly IMaterialRepository _materialRepository;

        public CreateVideo(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public bool TryCreateVideo(VideoMaterial video)
        {
            CreateVideoValidation validations = new CreateVideoValidation();
            ValidationResult validationResult = validations.Validate(video);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _materialRepository.GetMaterials();
            Material? existingMaterial = _materialRepository.GetMaterialByName(video.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _materialRepository.SetMaterial(video);
                return true;
            }
        }
    }
}
