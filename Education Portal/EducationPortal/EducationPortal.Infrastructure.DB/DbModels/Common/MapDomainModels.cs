using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.DB.DbModels.Common
{
    internal static class MapDomainModels
    {
        public static User MapDbUserToUser(this DbUser user)
        {
            var skills = new List<Skill>();
            if (user.UserSkills != null)
            {
                foreach (var skill in user.UserSkills)
                {
                    if (user.Id == skill.UserId)
                    {
                        skills.Add(skill.Skill.MapDbSkillToSkill());
                    }
                }
            }

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Skills = skills
            };
        }

        public static DbUser MapUserToDbUser(this User user)
        {
            var skills = new List<DbSkill>();
            foreach (var skill in user.Skills)
            {
                skills.Add(skill.MapSkillToDbSkill());
            }

            return new DbUser
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Skills = skills
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

            var skills = new List<Skill>();
            if (course.Skills != null)
            {
                foreach (var skill in course.Skills)
                {
                    skills.Add(skill.MapDbSkillToSkill());
                }
            }

            return new Course
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials,
                Skills = skills
            };
        }

        public static DbCourse MapCourseToDbCourse(this Course course)
        {
            var materials = new List<DbMaterial>();
            foreach (var material in course.Materials)
            {
                materials.Add(material.MapMaterialToDbMaterial());
            }

            var skills = new List<DbSkill>();
            foreach (var skill in course.Skills)
            {
                skills.Add(skill.MapSkillToDbSkill());
            }

            return new DbCourse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials,
                Skills = skills
            };
        }

        public static Skill MapDbSkillToSkill(this DbSkill skill)
        {
            return new Skill
            {
                Id = skill.Id,
                Title = skill.Title
            };
        }

        public static DbSkill MapSkillToDbSkill(this Skill skill)
        {
            return new DbSkill
            {
                Id = skill.Id,
                Title = skill.Title
            };
        }
    }
}
