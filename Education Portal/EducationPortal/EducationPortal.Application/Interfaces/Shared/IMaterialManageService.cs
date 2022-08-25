using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public List<BookMaterial> GetBooks();

        public void SetBook(BookMaterial book);

        public void UpdateBook(string name, BookMaterial updatedMaterial);

        public void DeleteBook(string name);

        public List<VideoMaterial> GetVideo();

        public void SetVideo(VideoMaterial book);

        public void UpdateVideo(string name, VideoMaterial updatedMaterial);

        public void DeleteVideo(string name);

        public List<ArticleMaterial> GetArticle();

        public void SetArticle(ArticleMaterial book);

        public void UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial);

        public void DeleteArticle(string name);
    }
}
