namespace EducationPortal.UI.Services.Interfaces
{
    public interface IMaterialEditService
    {
        public Task<List<MaterialView>> GetMaterials();

        public Task SetArticle(ArticleView material);

        public Task SetBook(BookView material);

        public Task SetVideo(VideoView material);

        public Task RemoveArticle(ArticleView material);

        public Task RemoveBook(BookView material);

        public Task RemoveVideo(VideoView material);

        public Task UpdateArticle(ArticleView material);

        public Task UpdateBook(BookView material);

        public Task UpdateVideo(VideoView material);

        public Task<ArticleView>? GetByIdArticle(int id);

        public Task<BookView>? GetByIdBook(int id);

        public Task<VideoView>? GetByIdVideo(int id);
    }
}
