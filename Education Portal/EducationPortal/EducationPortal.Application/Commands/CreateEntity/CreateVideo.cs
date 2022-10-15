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

        public async Task<bool> TryCreateVideo(VideoMaterial video)
        {
            CreateVideoValidation validations = new CreateVideoValidation();
            ValidationResult validationResult = validations.Validate(video);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var videoNameSpecification = new SpecificationBase<VideoMaterial>(x => x.Name == video.Name);
            var checkArticle = await _videoRepository.Find(videoNameSpecification);
            if (checkArticle.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                await _videoRepository.Add(video);
                return true;
            }
        }
    }
}
