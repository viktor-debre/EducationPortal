using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;
using FluentValidation.Results;

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

            var checkArticle = _videoRepository.GetVideos().FirstOrDefault(x => x.Name == video.Name);
            if (checkArticle != null)
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
