using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Repository
{
    public interface IVideoRepository
    {
        public List<VideoMaterial> GetVideos();

        public VideoMaterial GetVideoById(int id);

        public void SetVideo(VideoMaterial material);

        public void UpdateVideo(string name, VideoMaterial updatedMaterial);

        public void DeleteVideo(VideoMaterial material);

        public void Save();
    }
}
