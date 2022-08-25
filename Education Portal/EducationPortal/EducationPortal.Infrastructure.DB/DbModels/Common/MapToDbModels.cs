using EducationPortal.Domain.Common;
using EducationPortal.Domain.Entities;

namespace EducationPortal.Infrastructure.DB.DbModels.Common
{
    internal class MapToDbModels
    {
        private readonly PortalContext _context;

        public MapToDbModels(PortalContext context)
        {
            _context = context;
        }

        public DbBaseEntity MapToDbEntity(BaseEntity entity)
        {
            if (entity is Material material)
            {
                return MapToDbMaterial(material);
            }
            else if (entity is Skill skill)
            {
                return MapToDbSkill(skill);
            }

            throw new Exception("Not found entity type to map");
        }

        private DbMaterial MapToDbMaterial(Material material)
        {
            int id = material.Id;
            DbMaterial materialInDb;
            if (id != 0)
            {
                materialInDb = _context.Materials.Find(id);
            }
            else
            {
                materialInDb = new DbMaterial();
            }

            if (material is BookMaterial book)
            {
                DbBookMaterial result;
                if (id == 0)
                {
                    result = new DbBookMaterial();
                }
                else
                {
                    result = materialInDb as DbBookMaterial;
                }

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
                DbVideoMaterial result;
                if (id == 0)
                {
                    result = new DbVideoMaterial();
                }
                else
                {
                    result = materialInDb as DbVideoMaterial;
                }

                result.Id = video.Id;
                result.Id = video.Id;
                result.Name = video.Name;
                result.Quality = video.Quality;
                result.Duration = video.Duration;
                return result;
            }

            if (material is ArticleMaterial article)
            {
                DbArticleMaterial result;
                if (id == 0)
                {
                    result = new DbArticleMaterial();
                }
                else
                {
                    result = materialInDb as DbArticleMaterial;
                }

                result.Id = article.Id;
                result.Name = article.Name;
                result.Source = article.Source;
                result.PublicationDate = article.PublicationDate;
                return result;
            }

            throw new Exception("Unkown type material!");
        }

        private DbSkill MapToDbSkill(Skill skill)
        {
            int id = skill.Id;
            DbSkill materialInDb;
            if (id != 0)
            {
                materialInDb = _context.Skills.Find(id);
            }
            else
            {
                materialInDb = new DbSkill();
            }

            materialInDb.Id = skill.Id;
            materialInDb.Title = skill.Title;
            return materialInDb;
        }
    }
}
