using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class ArticleRepository : IArticleRepository
    {
        public List<ArticleMaterial> Articles { get; set; }
        private const string articlePath = @"D:\work\article.json";
        private readonly StorageManager<ArticleMaterial> _storage = new StorageManager<ArticleMaterial>();

        public ArticleRepository()
        {
            Articles = new List<ArticleMaterial>();
        }

        public List<ArticleMaterial> GetArticle()
        {
            List<ArticleMaterial> materials = _storage.ExctractItemsFromStorage(articlePath);
            if (materials != null)
            {
                Articles = materials;
            }
            return Articles;
        }

        public ArticleMaterial? GetArticleByName(string name)
        {
            return Articles.FirstOrDefault(x => x.Name == name);
        }

        public void SetArticle(ArticleMaterial material)
        {
            Articles.Add(material);
            _storage.AddItemToStorage(Articles, articlePath);
        }

        public void UpdateArticle(string name, ArticleMaterial updatedMaterial)
        {
            if (DeleteArticle(name))
            {
                SetArticle(updatedMaterial);
            }
        }

        public bool DeleteArticle(string name)
        {
            var material = GetArticleByName(name);
            if (material != null)
            {
                Articles.Remove(material);
                _storage.AddItemToStorage(Articles, articlePath);
                return true;
            }
            return false;
        }
    }
}
