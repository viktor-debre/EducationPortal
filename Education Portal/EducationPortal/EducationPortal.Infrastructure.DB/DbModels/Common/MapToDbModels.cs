﻿using EducationPortal.Domain.Common;
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

        public BaseEntity MapToDomainEntity(DbBaseEntity dbEntity)
        {
            if (dbEntity is DbMaterial material)
            {
                return MapToDomainMaterial(material);
            }
            else if (dbEntity is DbSkill skill)
            {
                return MapToDomainSkill(skill);
            }
            else if (dbEntity is DbUser user)
            {
                return MapToDomainUser(user);
            }
            else if (dbEntity is DbCourse course)
            {
                return MapToDomainCourse(course);
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

        private User MapToDomainUser(DbUser user)
        {
            var skills = new List<Skill>();
            if (user.UserSkills != null)
            {
                foreach (var skill in user.UserSkills)
                {
                    if (user.Id == skill.UserId)
                    {
                        skills.Add(skill.Skill.MapToDomainSkill());
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

        private Material MapToDomainMaterial(DbMaterial material)
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

        private Course MapToDomainCourse(DbCourse course)
        {
            var materials = new List<Material>();
            if (course.Materials != null)
            {
                foreach (var material in course.Materials)
                {
                    materials.Add(material.MapToDomainMaterial());
                }
            }

            var skills = new List<Skill>();
            if (course.Skills != null)
            {
                foreach (var skill in course.Skills)
                {
                    skills.Add(skill.MapToDomainSkill());
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

        private Skill MapToDomainSkill(DbSkill skill)
        {
            return new Skill
            {
                Id = skill.Id,
                Title = skill.Title
            };
        }
    }
}
