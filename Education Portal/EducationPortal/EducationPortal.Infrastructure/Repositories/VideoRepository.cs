using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class VideoRepository : IVideoRepository
    {
        private const string VideoPath = @"D:\work\video.json";

        private readonly StorageManager<VideoMaterial> _storage = new StorageManager<VideoMaterial>();

        public VideoRepository()
        {
            Videos = new List<VideoMaterial>();
        }

        public List<VideoMaterial> Videos { get; set; }

        public List<VideoMaterial> GetVideos()
        {
            List<VideoMaterial> materials = _storage.ExctractItemsFromStorage(VideoPath);
            if (materials != null)
            {
                Videos = materials;
            }

            return Videos;
        }

        public VideoMaterial? GetVideoById(string name)
        {
            return Videos.FirstOrDefault(x => x.Name == name);
        }

        public void SetVideo(VideoMaterial material)
        {
            Videos.Add(material);
            _storage.AddItemToStorage(Videos, VideoPath);
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
            var material = GetVideoById(name);
            if (material != null)
            {
                Videos.Remove(material);
                _storage.AddItemToStorage(Videos, VideoPath);
                return true;
            }

            return false;
        }

        public VideoMaterial GetVideoById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVideo(VideoMaterial material)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        void IVideoRepository.DeleteVideo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
