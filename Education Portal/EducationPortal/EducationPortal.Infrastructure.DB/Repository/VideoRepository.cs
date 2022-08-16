using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class VideoRepository : IVideoRepository
    {
        private readonly PortalContext _context;

        public VideoRepository(PortalContext context)
        {
            _context = context;
        }

        public void DeleteVideo(string name)
        {
            var video = _context.Materials.FirstOrDefault(x => x.Name == name);
            if (video != null)
            {
                _context.Materials.Remove(video);
                Save();
            }
        }

        public VideoMaterial? GetVideoById(int id)
        {
            return (VideoMaterial?)_context.Materials.Find(id).MapDbMaterialToMaterial();
        }

        public List<VideoMaterial> GetVideos()
        {
            List<VideoMaterial> videos = new List<VideoMaterial>();
            foreach (var video in _context.Materials)
            {
                if (video is DbVideoMaterial)
                {
                    videos.Add((VideoMaterial)video.MapDbMaterialToMaterial());
                }
            }

            return videos;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetVideo(VideoMaterial material)
        {
            _context.Materials.Add(material.MapMaterialToDbMaterial());
            Save();
        }

        public void UpdateVideo(string name, VideoMaterial updatedMaterial)
        {
            DbVideoMaterial video = (DbVideoMaterial)_context.Materials.FirstOrDefault(x => x.Name == name);
            if (video != null)
            {
                _context.Update(video);
                video.Name = updatedMaterial.Name;
                video.Duration = updatedMaterial.Duration;
                video.Quality = updatedMaterial.Quality;
                Save();
            }
        }
    }
}
