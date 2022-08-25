using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class VideoRepository : IVideoRepository
    {
        private readonly PortalContext _context;
        private readonly MapToDbModels _mapper;

        public VideoRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapToDbModels(context);
        }

        public void DeleteVideo(VideoMaterial material)
        {
            _context.Materials.Remove(_mapper.MapToDbMaterial(material));
            Save();
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
            _context.Materials.Add(_mapper.MapToDbMaterial(material));
            Save();
        }

        public void UpdateVideo(VideoMaterial material)
        {
            _context.Entry(_mapper.MapToDbMaterial(material)).State = EntityState.Modified;
            Save();
        }
    }
}
