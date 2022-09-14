using EducationPortal.Domain.Entities;

namespace EducationPortal.UI.Models.Mapping
{
    public class MapperForViewModels : IMapper
    {
        public UserView MapUserToViewModel(User user)
        {
            var materialsList = new List<MaterialView>();
            foreach (var material in user.Materials)
            {
                materialsList.Add(MapMaterialToViewModel(material));
            }

            var skillList = new List<SkillView>();
            foreach (var skill in user.Skills)
            {
                skillList.Add(MapSkillToViewModel(skill));
            }

            return new UserView()
            {
                Name = user.Name,
                Password = user.Password,
                Materials = materialsList,
                Skills = skillList
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

            throw new Exception("Unkown type material!");
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
    }
}