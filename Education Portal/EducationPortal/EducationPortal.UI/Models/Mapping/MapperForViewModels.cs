using EducationPortal.Domain.Entities;

namespace EducationPortal.UI.Models.Mapping
{
    public class MapperForViewModels : IMapper
    {
        public UserView MapUserToViewModel(User user)
        {
            var skills = new List<SkillView>();
            if (user.Skills != null)
            {
                foreach (var skill in user.Skills)
                {
                    skills.Add(MapSkillToViewModel(skill));
                }
            }

            var materials = new List<MaterialView>();
            if (user.Materials != null)
            {
                foreach (var material in user.Materials)
                {
                    materials.Add(MapMaterialToViewModel(material));
                }
            }

            var courses = new List<CourseView>();
            if (user.Courses != null)
            {
                foreach (var course in user.Courses)
                {
                    courses.Add(MapCourseToViewModel(course));
                }
            }

            var userCourses = new List<UserCourseView>();
            if (user.UserCourses != null)
            {
                foreach (var userCourse in user.UserCourses)
                {
                    userCourses.Add(MapUserCourseToViewModel(userCourse));
                }
            }

            var userSkills = new List<UserSkillView>();
            if (user.UserSkills != null)
            {
                foreach (var userSkill in user.UserSkills)
                {
                    userSkills.Add(MapUserSkillToViewModel(userSkill));
                }
            }

            return new UserView
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

        public User MapUserToDomainModel(UserView user)
        {
            var skills = new List<Skill>();
            if (user.Skills != null)
            {
                foreach (var skill in user.Skills)
                {
                    skills.Add(MapSkillToDomainModel(skill));
                }
            }

            var materials = new List<Material>();
            if (user.Materials != null)
            {
                foreach (var material in user.Materials)
                {
                    materials.Add(MapMaterialToDomainModel(material));
                }
            }

            var courses = new List<Course>();
            if (user.Courses != null)
            {
                foreach (var course in user.Courses)
                {
                    courses.Add(MapCourseToDomainModel(course));
                }
            }

            var userCourses = new List<UserCourse>();
            if (user.UserCourses != null)
            {
                foreach (var userCourse in user.UserCourses)
                {
                    userCourses.Add(MapUserCourseToDomainModel(userCourse));
                }
            }

            var userSkills = new List<UserSkill>();
            if (user.UserSkills != null)
            {
                foreach (var userSkill in user.UserSkills)
                {
                    userSkills.Add(MapUserSkillToDomainModel(userSkill));
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

        public MaterialView MapMaterialToViewModel(Material material)
        {
            if (material is BookMaterial book)
            {
                BookView result = new BookView
                {
                    Id = book.Id,
                    Name = book.Name,
                    NumberPages = book.NumberPages,
                    Format = book.Format,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate
                };
                return result;
            }

            if (material is VideoMaterial video)
            {
                VideoView result = new VideoView
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Duration = video.Duration
                };
                return result;
            }

            if (material is ArticleMaterial article)
            {
                ArticleView result = new ArticleView
                {
                    Id = article.Id,
                    Name = article.Name,
                    Source = article.Source,
                    PublicationDate = article.PublicationDate
                };
                return result;
            }

            throw new Exception("Unknown type material!");
        }

        public Material MapMaterialToDomainModel(MaterialView material)
        {
            if (material is BookView book)
            {
                BookMaterial result = new BookMaterial
                {
                    Id = book.Id,
                    Name = book.Name,
                    NumberPages = book.NumberPages,
                    Format = book.Format,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate
                };
                return result;
            }

            if (material is VideoView video)
            {
                VideoMaterial result = new VideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Duration = video.Duration
                };
                return result;
            }

            if (material is ArticleView article)
            {
                ArticleMaterial result = new ArticleMaterial
                {
                    Id = article.Id,
                    Name = article.Name,
                    Source = article.Source,
                    PublicationDate = article.PublicationDate
                };
                return result;
            }

            throw new Exception("Unknown type material!");
        }

        public SkillView MapSkillToViewModel(Skill skill)
        {
            SkillView skillToView = new SkillView
            {
                Id = skill.Id,
                Title = skill.Title
            };
            return skillToView;
        }

        public Skill MapSkillToDomainModel(SkillView skill)
        {
            Skill domainSkill = new Skill
            {
                Id = skill.Id,
                Title = skill.Title
            };
            return domainSkill;
        }

        public UserCourseView MapUserCourseToViewModel(UserCourse userCourse)
        {
            return new UserCourseView
            {
                UserId = userCourse.UserId,
                CourseId = userCourse.CourseId,
                Status = userCourse.Status,
                PassPercent = userCourse.PassPercent
            };
        }

        public UserCourse MapUserCourseToDomainModel(UserCourseView userCourse)
        {
            return new UserCourse
            {
                UserId = userCourse.UserId,
                CourseId = userCourse.CourseId,
                Status = userCourse.Status,
                PassPercent = userCourse.PassPercent
            };
        }

        public UserSkillView MapUserSkillToViewModel(UserSkill userSkill)
        {
            return new UserSkillView
            {
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId,
                Level = userSkill.Level
            };
        }

        public UserSkill MapUserSkillToDomainModel(UserSkillView userSkill)
        {
            return new UserSkill
            {
                UserId = userSkill.UserId,
                SkillId = userSkill.SkillId,
                Level = userSkill.Level
            };
        }

        public CourseView MapCourseToViewModel(Course course)
        {
            var materials = new List<MaterialView>();
            if (course.Materials != null)
            {
                foreach (var material in course.Materials)
                {
                    materials.Add(MapMaterialToViewModel(material));
                }
            }

            var skills = new List<SkillView>();
            if (course.Skills != null)
            {
                foreach (var skill in course.Skills)
                {
                    skills.Add(MapSkillToViewModel(skill));
                }
            }

            return new CourseView
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Materials = materials,
                Skills = skills
            };
        }

        public Course MapCourseToDomainModel(CourseView course)
        {
            var materials = new List<Material>();
            if (course.Materials != null)
            {
                foreach (var material in course.Materials)
                {
                    materials.Add(MapMaterialToDomainModel(material));
                }
            }

            var skills = new List<Skill>();
            if (course.Skills != null)
            {
                foreach (var skill in course.Skills)
                {
                    skills.Add(MapSkillToDomainModel(skill));
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
    }
}