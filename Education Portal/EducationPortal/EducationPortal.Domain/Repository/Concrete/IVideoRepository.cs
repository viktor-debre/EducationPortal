namespace EducationPortal.Domain.Repository
{
    public interface IVideoRepository
    {
        public List<VideoMaterial> GetVideos();

        public VideoMaterial GetVideoById(int id);

        public void SetVideo(VideoMaterial material);

        public void UpdateVideo(VideoMaterial material);

        public void DeleteVideo(VideoMaterial material);

        public void Save();
    }
}
