using EducationPortal.Domain.Common;
using EducationPortal.Domain.Entities;

namespace EducationPortal.Infrastructure.DB.Mapping
{
    internal class MapperForEntities
    {
        private readonly PortalContext _context;

        public MapperForEntities(PortalContext context)
        {
            _context = context;
        }

        public async Task<DbBaseEntity> MapToDbEntity(BaseEntity entity)
        {
            if (entity is Material material)
            {
                return await MapToDbMaterial(material);
            }
            else if (entity is Skill skill)
            {
                return await MapToDbSkill(skill);
            }
            else if (entity is User user)
            {
                return await MapToDbUser(user);
            }
            else if (entity is Course course)
            {
                return await MapToDbCourse(course);
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

        public User MapToDomainUser(DbUser user)
        {
            var skills = new List<Skill>();
            if (user.Skills != null)
            {
                foreach (var skill in user.Skills)
                {
                    skills.Add(MapToDomainSkill(skill));
                }
            }

            var materials = new List<Material>();
            if (user.Materials != null)
            {
                foreach (var material in user.Materials)
                {
                    materials.Add(MapToDomainMaterial(material));
                }
            }

            var courses = new List<Course>();
            if (user.Courses != null)
            {
                foreach (var course in user.Courses)
                {
                    courses.Add(MapToDomainCourse(course));
                }
            }

            var userCourses = new List<UserCourse>();
            if (user.UserCourses != null)
            {
                foreach (var userCourse in user.UserCourses)
                {
                    userCourses.Add(MapToDomainUserCourse(userCourse));
                }
            }

            var userSkills = new List<UserSkill>();
            if (user.UserSkills != null)
            {
                foreach (var userSkill in user.UserSkills)
                {
                    userSkills.Add(MapToDomainUserSkill(userSkill));
                }
            }

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Skills = skills,
                Materials = materials,
                Courses = courses,
                UserCourses = userCourses,
                UserSkills = userSkills
            };
        }

        public UserSkill MapToDomainUserSkill(DbUserSkill userSkill)
        {
            return new UserSkill
            {
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId,
                Level = userSkill.Level
            };
        }

        public UserCourse MapToDomainUserCourse(DbUserCourse userCourse)
        {
            return new UserCourse
            {
                UserId = userCourse.UserId,
                CourseId = userCourse.CourseId,
                Status = userCourse.Status,
                PassPercent = userCourse.PassPercent
            };
        }

        public Material MapToDomainMaterial(DbMaterial material)
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

        public Course MapToDomainCourse(DbCourse course)
        {
            var materials = new List<Material>();
            if (course.Materials != null)
            {
                foreach (var material in course.Materials)
                {
                    materials.Add(MapToDomainMaterial(material));
                }
            }

            var skills = new List<Skill>();
            if (course.Skills != null)
            {
                foreach (var skill in course.Skills)
                {
                    skills.Add(MapToDomainSkill(skill));
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

        public Skill MapToDomainSkill(DbSkill skill)
        {
            return new Skill
            {
                Id = skill.Id,
                Title = skill.Title
            };
        }

        public async Task<DbUser> MapToDbUser(User user)
        {
            int id = user.Id;
            DbUser userInDb;
            if (id != 0)
            {
                userInDb = await _context.Users.FindAsync(id);
            }
            else
            {
                userInDb = new DbUser();
            }

            var skills = new List<DbSkill>();
            foreach (var skill in user.Skills)
            {
                skills.Add(await _context.Skills.FindAsync(skill.Id));
            }

            var materials = new List<DbMaterial>();
            foreach (var material in user.Materials)
            {
                materials.Add(await MapToDbMaterial(material));
            }

            var courses = new List<DbCourse>();
            foreach (var course in user.Courses)
            {
                courses.Add(await MapToDbCourse(course));
            }

            var userCourses = new List<DbUserCourse>();

            foreach (var userCourse in user.UserCourses)
            {
                userCourses.Add(await MapToDbUserCourse(userCourse));
            }

            var userSkills = new List<DbUserSkill>();
            foreach (var userSkill in user.UserSkills)
            {
                userSkills.Add(await MapToDbUserSkill(userSkill));
            }

            userInDb.Id = user.Id;
            userInDb.Name = user.Name;
            userInDb.Password = user.Password;
            userInDb.Skills = skills;
            userInDb.Materials = materials;
            userInDb.Courses = courses;
            userInDb.UserCourses = userCourses;
            userInDb.UserSkills = userSkills;

            return userInDb;
        }

        public async Task<DbUserSkill> MapToDbUserSkill(UserSkill userSkill)
        {
            int skillId = userSkill.SkillId;
            int userId = userSkill.UserId;
            var user = _context.UserSkills.FirstOrDefault(x => x.SkillId == skillId && x.UserId == userId);
            DbUserSkill userSkillInDb = user ?? new DbUserSkill();

            userSkillInDb.UserId = userSkill.UserId;
            userSkillInDb.SkillId = userSkill.SkillId;
            userSkillInDb.Level = userSkill.Level;
            return userSkillInDb;
        }

        public async Task<DbUserCourse> MapToDbUserCourse(UserCourse userCourse)
        {
            int courseId = userCourse.CourseId;
            int userId = userCourse.UserId;

            var user = _context.UserCourses.FirstOrDefault(x => x.CourseId == courseId && x.UserId == userId);
            DbUserCourse userCourseInDb = user ?? new DbUserCourse();

            userCourseInDb.CourseId = userCourse.CourseId;
            userCourseInDb.UserId = userCourse.UserId;
            userCourseInDb.Status = userCourse.Status;
            userCourseInDb.PassPercent = userCourse.PassPercent;

            return userCourseInDb;
        }

        public async Task<DbMaterial> MapToDbMaterial(Material material)
        {
            int id = material.Id;
            DbMaterial materialInDb;
            if (id != 0)
            {
                materialInDb = await _context.Materials.FindAsync(id);
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

            throw new Exception("Unknown type material!");
        }

        public async Task<DbSkill> MapToDbSkill(Skill skill)
        {
            int id = skill.Id;
            DbSkill skillInDb;
            if (id != 0)
            {
                skillInDb = await _context.Skills.FindAsync(id);
            }
            else
            {
                skillInDb = new DbSkill();
            }

            skillInDb.Id = skill.Id;
            skillInDb.Title = skill.Title;
            return skillInDb;
        }

        public async Task<DbCourse> MapToDbCourse(Course course)
        {
            int id = course.Id;
            DbCourse courseInDb;
            if (id != 0)
            {
                courseInDb = await _context.Courses.FindAsync(id);
            }
            else
            {
                courseInDb = new DbCourse();
            }

            var materials = new List<DbMaterial>();
            foreach (var material in course.Materials)
            {
                materials.Add(await MapToDbMaterial(material));
            }

            var skills = new List<DbSkill>();
            foreach (var skill in course.Skills)
            {
                skills.Add(await MapToDbSkill(skill));
            }

            courseInDb.Id = course.Id;
            courseInDb.Name = course.Name;
            courseInDb.Description = course.Description;
            courseInDb.Materials = materials;
            courseInDb.Skills = skills;
            return courseInDb;
        }
    }
}
