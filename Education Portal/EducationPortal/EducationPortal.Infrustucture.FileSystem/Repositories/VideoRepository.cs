using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class VideoRepository : IRepository<VideoMaterial>
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

        public VideoMaterial? GetVideoByName(string name)
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
            var material = GetVideoByName(name);
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

        public void UpdateVideo(VideoMaterial material)
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

        public List<VideoMaterial> Find()
        {
            throw new NotImplementedException();
        }

        public VideoMaterial FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(VideoMaterial item)
        {
            throw new NotImplementedException();
        }

        public void Update(VideoMaterial item)
        {
            throw new NotImplementedException();
        }

        public void Remove(VideoMaterial entity)
        {
            throw new NotImplementedException();
        }
    }
}
