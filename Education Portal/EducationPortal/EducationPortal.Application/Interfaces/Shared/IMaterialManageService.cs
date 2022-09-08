namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public List<BookMaterial> GetBooks();

        public BookMaterial? GetBookByName(string name);

        public void SetBook(BookMaterial book);

        public void UpdateBook(BookMaterial material, BookMaterial updatedMaterial);

        public void DeleteBook(string name);

        public List<VideoMaterial> GetVideos();

        public VideoMaterial? GetVideosByName(string name);

        public void SetVideo(VideoMaterial book);

        public void UpdateVideo(VideoMaterial material, VideoMaterial updatedMaterial);

        public void DeleteVideo(string name);

        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleByName(string name);

        public void SetArticle(ArticleMaterial book);

        public void UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial);

        public void DeleteArticle(string name);
    }
}
