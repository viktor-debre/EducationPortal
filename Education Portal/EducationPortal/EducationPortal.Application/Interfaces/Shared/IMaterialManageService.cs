namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public Task<List<BookMaterial>> GetBooks();

        public Task<BookMaterial?> GetBookByName(string name);

        public Task SetBook(BookMaterial book);

        public Task UpdateBook(BookMaterial material, BookMaterial updatedMaterial);

        public Task DeleteBook(string name);

        public Task<List<VideoMaterial>> GetVideos();

        public Task<VideoMaterial?> GetVideoByName(string name);

        public Task SetVideo(VideoMaterial book);

        public Task UpdateVideo(VideoMaterial material, VideoMaterial updatedMaterial);

        public Task DeleteVideo(string name);

        public Task<List<ArticleMaterial>> GetArticle();

        public Task<ArticleMaterial?> GetArticleByName(string name);

        public Task SetArticle(ArticleMaterial book);

        public Task UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial);

        public Task DeleteArticle(string name);
    }
}
