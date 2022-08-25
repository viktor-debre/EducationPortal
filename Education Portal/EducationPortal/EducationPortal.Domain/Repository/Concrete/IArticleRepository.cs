namespace EducationPortal.Domain.Repository
{
    public interface IArticleRepository
    {
        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleById(int id);

        public void SetArticle(ArticleMaterial material);

        public void UpdateArticle(ArticleMaterial material);

        public void DeleteArticle(int id);

        public void Save();
    }
}
