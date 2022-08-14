using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using FluentValidation.Results;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Application.Commands
{
    internal class CreateVideo
    {
        private readonly IVideoRepository _videoRepository;

        public CreateVideo(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public bool TryCreateVideo(VideoMaterial video)
        {
            CreateVideoValidation validations = new CreateVideoValidation();
            ValidationResult validationResult = validations.Validate(video);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _videoRepository.GetVideos();
            Material? existingMaterial = _videoRepository.GetVideoByName(video.Name);
            if (existingMaterial != null)
            {
                return false;
            }
            else
            {
                _videoRepository.SetVideo(video);
                return true;
            }
        }
    }
}
