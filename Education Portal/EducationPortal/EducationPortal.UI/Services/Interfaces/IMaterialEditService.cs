namespace EducationPortal.UI.Services.Interfaces
{
    public interface IMaterialEditService
    {
        public Task<List<MaterialView>> GetMaterials();

        public Task SetArticle(ArticleView material);

        public Task SetBook(BookView material);

        public Task SetVideo(VideoView material);

        public Task RemoveMaterial(MaterialView material);

        public Task UpdateArticle(ArticleView material);

        public Task UpdateBook(BookView material);

        public Task UpdateVideo(VideoView material);

        public Task<MaterialView> GetByIdMaterial(int id);
    }
}
