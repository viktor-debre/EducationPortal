using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class ArticleRepository : IArticleRepository
    {
        private const string ArticlePath = @"D:\work\article.json";

        private readonly StorageManager<ArticleMaterial> _storage = new StorageManager<ArticleMaterial>();

        public ArticleRepository()
        {
            Articles = new List<ArticleMaterial>();
        }

        public List<ArticleMaterial> Articles { get; set; }

        public List<ArticleMaterial> GetArticle()
        {
            List<ArticleMaterial> materials = _storage.ExctractItemsFromStorage(ArticlePath);
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
            _storage.AddItemToStorage(Articles, ArticlePath);
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
                _storage.AddItemToStorage(Articles, ArticlePath);
                return true;
            }

            return false;
        }
    }
}
