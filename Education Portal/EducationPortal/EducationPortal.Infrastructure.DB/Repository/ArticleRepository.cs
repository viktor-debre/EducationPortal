using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class ArticleRepository : IArticleRepository
    {
        private readonly PortalContext _context;

        public ArticleRepository(PortalContext context)
        {
            _context = context;
        }

        public void DeleteArticle(string name)
        {
            var article = _context.Materials.FirstOrDefault(x => x.Name == name);
            if (article != null)
            {
                _context.Materials.Remove(article);
                Save();
            }
        }

        public List<ArticleMaterial> GetArticle()
        {
            List<ArticleMaterial> articles = new List<ArticleMaterial>();
            foreach (var article in _context.Materials)
            {
                if (article is DbArticleMaterial)
                {
                    articles.Add((ArticleMaterial)article.MapDbMaterialToMaterial());
                }
            }

            return articles;
        }

        public ArticleMaterial? GetArticleById(int id)
        {
            return (ArticleMaterial?)_context.Materials.Find(id).MapDbMaterialToMaterial();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetArticle(ArticleMaterial material)
        {
            _context.Add(material.MapMaterialToDbMaterial());
            Save();
        }

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial)
        {
            _context.Entry(updatedMaterial.MapMaterialToDbMaterial()).State = EntityState.Modified;
            Save();
        }
    }
}
