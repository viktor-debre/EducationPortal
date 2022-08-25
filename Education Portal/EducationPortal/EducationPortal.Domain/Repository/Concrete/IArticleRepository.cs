namespace EducationPortal.Domain.Repository
{
    public interface IArticleRepository
    {
        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleById(int id);

        public void SetArticle(ArticleMaterial material);

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial);

        public void DeleteArticle(int id);

        public void Save();
    }
}
