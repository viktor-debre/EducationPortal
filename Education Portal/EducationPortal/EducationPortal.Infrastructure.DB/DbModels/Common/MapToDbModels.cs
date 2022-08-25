using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.DB.DbModels.Common
{
    internal class MapToDbModels
    {
        private readonly PortalContext _context;

        public MapToDbModels(PortalContext context)
        {
            _context = context;
        }

        public DbMaterial MapMaterialToDbMaterial(Material material)
        {
            int id = material.Id;
            DbMaterial materialInDb = _context.Materials.Find(id) ?? new DbMaterial();
            if (material is BookMaterial book)
            {
                DbBookMaterial result = materialInDb as DbBookMaterial;
                result.Id = book.Id;
                result.Name = book.Name;
                result.NumberPages = book.NumberPages;
                result.Format = book.Format;
                result.Author = book.Author;
                result.PublicationDate = book.PublicationDate;
                return result;
            }

            if (material is VideoMaterial video)
            {
                DbVideoMaterial result = materialInDb as DbVideoMaterial;
                result.Id = video.Id;
                result.Name = video.Name;
                result.Quality = video.Quality;
                result.Duration = video.Duration;
                return result;
            }

            if (material is ArticleMaterial article)
            {
                DbArticleMaterial result = materialInDb as DbArticleMaterial;
                result.Id = article.Id;
                result.Name = article.Name;
                result.Source = article.Source;
                result.PublicationDate = article.PublicationDate;
                return result;
            }

            throw new Exception("Unkown type material!");
        }
    }
}
