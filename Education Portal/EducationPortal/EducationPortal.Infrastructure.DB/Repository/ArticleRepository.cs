using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class ArticleRepository : IArticleRepository
    {
        private readonly PortalContext _context;
        private readonly MapToDbModels _mapper;

        public ArticleRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapToDbModels(context);
        }

        public void DeleteArticle(int id)
        {
            var article = _context.Materials.Find(id);
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
            _context.Materials.Add(material.MapMaterialToDbMaterial());
            Save();
        }

        public void UpdateArticle(ArticleMaterial material)
        {
            _context.Entry(_mapper.MapMaterialToDbMaterial(material)).State = EntityState.Modified;
            Save();
        }
    }
}
