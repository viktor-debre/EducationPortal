using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class ArticleRepository : IArticleRepository
    {
        private readonly PortalContext _portalContext;

        public ArticleRepository(PortalContext context)
        {
            _portalContext = context;
        }

        public void DeleteArticle(string name)
        {
        }

        public List<ArticleMaterial> GetArticle()
        {
            throw new NotImplementedException();
        }

        public ArticleMaterial? GetArticleById(string name)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SetArticle(ArticleMaterial material)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial)
        {
            throw new NotImplementedException();
        }
    }
}
