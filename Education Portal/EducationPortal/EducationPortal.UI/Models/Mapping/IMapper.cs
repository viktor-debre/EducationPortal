using EducationPortal.Domain.Entities;

namespace EducationPortal.UI.Models.Mapping
{
    public interface IMapper
    {
        public UserView MapUserToViewModel(User user);

        public MaterialView MapMaterialToViewModel(Material material);

        public Material MapMaterialToDomainModel(MaterialView material);

        public SkillView MapSkillToViewModel(Skill skill);

        public Skill MapSkillToDomainModel(SkillView skill);
    }
}
