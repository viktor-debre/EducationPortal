using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IArticleRepository
    {
        public List<ArticleMaterial> Articles { get; }

        public List<ArticleMaterial> GetArticle();

        public ArticleMaterial? GetArticleByName(string name);

        public void SetArticle(ArticleMaterial material);

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial);

        public bool DeleteArticle(string name);
    }
}
