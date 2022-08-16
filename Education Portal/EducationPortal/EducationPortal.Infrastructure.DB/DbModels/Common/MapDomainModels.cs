using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.DB.DbModels.Common
{
    internal static class MapDomainModels
    {
        public static User MapDbUserToUser(this DbUser user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }

        public static DbUser MapUserToDbUser(this User user)
        {
            return new DbUser
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }

        public static DbMaterial MapMaterialToDbMaterial(this Material material)
        {
            DbMaterial result = new DbMaterial();
            if (material is BookMaterial book)
            {
                result = new DbBookMaterial
                {
                    Id = book.Id,
                    Name = book.Name,
                    NumberPages = book.NumberPages,
                    Format = book.Format,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate
                };
            }

            if (material is VideoMaterial video)
            {
                result = new DbVideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Duration = video.Duration
                };
            }

            if (material is ArticleMaterial article)
            {
                result = new DbArticleMaterial
                {
                    Id = article.Id,
                    Name = article.Name,
                    Source = article.Source,
                    PublicationDate = article.PublicationDate
                };
            }

            return result;
        }

        public static Material MapDbMaterialToMaterial(this DbMaterial material)
        {
            Material result = new Material();
            if (material is DbBookMaterial book)
            {
                result = new BookMaterial
                {
                    Id = book.Id,
                    Name = book.Name,
                    NumberPages = book.NumberPages,
                    Format = book.Format,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate
                };
            }

            if (material is DbVideoMaterial video)
            {
                result = new VideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Duration = video.Duration
                };
            }

            if (material is DbArticleMaterial article)
            {
                result = new ArticleMaterial
                {
                    Id = article.Id,
                    Name = article.Name,
                    Source = article.Source,
                    PublicationDate = article.PublicationDate
                };
            }

            return result;
        }

        public static Course MapDbCourseToCourse(this DbCourse course)
        {
            var materials = new List<Material>();
            if (course.Materials != null)
            {
                foreach (var material in course.Materials)
                {
                    materials.Add(material.MapDbMaterialToMaterial());
                }
            }

            return new Course
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials
            };
        }

        public static DbCourse MapCourseToDbCourse(this Course course)
        {
            var materials = new List<DbMaterial>();
            foreach (var material in course.Materials)
            {
                materials.Add(material.MapMaterialToDbMaterial());
            }

            return new DbCourse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials
            };
        }
    }
}
