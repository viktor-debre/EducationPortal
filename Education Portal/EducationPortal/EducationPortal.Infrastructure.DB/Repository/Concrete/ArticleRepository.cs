using EducationPortal.Domain.Entities;
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

        public void DeleteArticle(ArticleMaterial material)
        {
            _context.Materials.Remove((DbMaterial)_mapper.MapToDbEntity(material));
            Save();
        }

        public List<ArticleMaterial> GetArticle()
        {
            List<ArticleMaterial> articles = new List<ArticleMaterial>();
            foreach (var article in _context.Materials)
            {
                if (article is DbArticleMaterial)
                {
                    articles.Add((ArticleMaterial)article.MapToDomainMaterial());
                }
            }

            return articles;
        }

        public ArticleMaterial? GetArticleById(int id)
        {
            return (ArticleMaterial?)_context.Materials.Find(id).MapToDomainMaterial();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetArticle(ArticleMaterial material)
        {
            _context.Materials.Add((DbMaterial)_mapper.MapToDbEntity(material));
            Save();
        }

        public void UpdateArticle(ArticleMaterial material)
        {
            _context.Entry((DbMaterial)_mapper.MapToDbEntity(material)).State = EntityState.Modified;
            Save();
        }
    }
}
