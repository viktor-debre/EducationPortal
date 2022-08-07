using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IVideoRepository
    {
        public List<VideoMaterial> Videos { get; }

        public List<VideoMaterial> GetVideos();

        public VideoMaterial GetVideoByName(string name);

        public void SetVideo(VideoMaterial material);

        public void UpdateVideo(string name, VideoMaterial updatedMaterial);

        public bool DeleteVideo(string name);
    }
}
