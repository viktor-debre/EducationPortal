using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Repository
{
    public interface IArticleRepository
    {
        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleById(int id);

        public void SetArticle(ArticleMaterial material);

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial);

        public void DeleteArticle(ArticleMaterial name);

        public void Save();
    }
}
