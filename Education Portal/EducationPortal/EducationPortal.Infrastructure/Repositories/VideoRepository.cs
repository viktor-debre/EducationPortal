using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class VideoRepository : IVideoRepository
    {
        public List<VideoMaterial> Videos { get; set; }
        private const string videoPath = @"D:\work\video.json";
        private readonly StorageManager<VideoMaterial> _storage = new StorageManager<VideoMaterial>();

        public VideoRepository()
        {
            Videos = new List<VideoMaterial>();
        }
      
        public List<VideoMaterial> GetVideos()
        {
            List<VideoMaterial> materials = _storage.ExctractItemsFromStorage(videoPath);
            if (materials != null)
            {
                Videos = materials;
            }
            return Videos;
        }

        public VideoMaterial? GetVideoByName(string name)
        {
            return Videos.FirstOrDefault(x => x.Name == name);
        }

        public void SetVideo(VideoMaterial material)
        {
            Videos.Add(material);
            _storage.AddItemToStorage(Videos, videoPath);
        }

        public void UpdateVideo(string name, VideoMaterial updatedMaterial)
        {
            if (DeleteVideo(name))
            {
                SetVideo(updatedMaterial);
            }
        }

        public bool DeleteVideo(string name)
        {
            var material = GetVideoByName(name);
            if (material != null)
            {
                Videos.Remove(material);
                _storage.AddItemToStorage(Videos, videoPath);
                return true;
            }
            return false;
        }
    }
}
