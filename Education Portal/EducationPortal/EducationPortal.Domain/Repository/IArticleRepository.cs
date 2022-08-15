using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Repository
{
    public interface IArticleRepository
    {
        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleById(string name);

        public void SetArticle(ArticleMaterial material);

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial);

        public void DeleteArticle(string name);

        public void Save();
    }
}
