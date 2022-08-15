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

        public static ArticleMaterial MapDbArticleToArticle(this DbArticleMaterial article)
        {
            return new ArticleMaterial
            {
                Id = article.Id,
                Name = article.Name,
                Source = article.Source,
                PublicationDate = article.PublicationDate
            };
        }

        public static DbArticleMaterial MapArticleToDbArticle(this ArticleMaterial article)
        {
            return new DbArticleMaterial
            {
                Id = article.Id,
                Name = article.Name,
                Source = article.Source,
                PublicationDate = article.PublicationDate
            };
        }

        public static VideoMaterial MapDbVideoToVideo(this DbVideoMaterial video)
        {
            return new VideoMaterial
            {
                Id = video.Id,
                Name = video.Name,
                Quality = video.Quality,
                Duration = video.Duration
            };
        }

        public static DbVideoMaterial MapVideoToDbVideo(this VideoMaterial video)
        {
            return new DbVideoMaterial
            {
                Id = video.Id,
                Name = video.Name,
                Quality = video.Quality,
                Duration = video.Duration
            };
        }

        public static BookMaterial MapDbBookToBook(this DbBookMaterial book)
        {
            return new BookMaterial
            {
                Id = book.Id,
                Name = book.Name,
                NumberPages = book.NumberPages,
                Format = book.Format,
                Author = book.Author,
                PublicationDate = book.PublicationDate
            };
        }

        public static DbBookMaterial MapBookToDbBook(this BookMaterial book)
        {
            return new DbBookMaterial
            {
                Id = book.Id,
                Name = book.Name,
                NumberPages = book.NumberPages,
                Format = book.Format,
                Author = book.Author,
                PublicationDate = book.PublicationDate
            };
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
            foreach (var material in course.Materials)
            {
                materials.Add(material.MapDbMaterialToMaterial());
            }

            return new Course
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials
            };
        }
    }
}
