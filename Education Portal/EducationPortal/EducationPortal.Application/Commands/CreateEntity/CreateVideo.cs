using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
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

            var videoNameSpecification = new SpecificationBase<VideoMaterial>(x => x.Name == video.Name);
            var checkArticle = _videoRepository.Find(videoNameSpecification).FirstOrDefault();
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
