namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public Task<List<Material>> GetMaterials();

        public Task SetMaterial(Material material);

        public Task DeleteMaterial(Material material);

        public Task UpdateMaterial(Material material);

        public Task<List<BookMaterial>> GetBooks();

        public Task<BookMaterial?> GetBookByName(string name);

        public Task SetBook(BookMaterial book);

        public Task UpdateBook(BookMaterial material);

        public Task DeleteBook(string name);

        public Task<List<VideoMaterial>> GetVideos();

        public Task<VideoMaterial?> GetVideoByName(string name);

        public Task SetVideo(VideoMaterial book);

        public Task UpdateVideo(VideoMaterial material);

        public Task DeleteVideo(string name);

        public Task<List<ArticleMaterial>> GetArticles();

        public Task<ArticleMaterial?> GetArticleByName(string name);

        public Task SetArticle(ArticleMaterial book);

        public Task UpdateArticle(ArticleMaterial article);

        public Task DeleteArticle(string name);
    }
}
