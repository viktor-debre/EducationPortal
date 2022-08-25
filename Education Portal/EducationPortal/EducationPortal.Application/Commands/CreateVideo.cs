using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateVideo
    {
        private readonly IRepository<VideoMaterial> _videoRepository;

        public CreateVideo(IRepository<VideoMaterial> videoRepository)
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

            var checkArticle = _videoRepository.Find().FirstOrDefault(x => x.Name == video.Name);
            if (checkArticle != null)
            {
                return false;
            }
            else
            {
                _videoRepository.Add(video);
                return true;
            }
        }
    }
}
