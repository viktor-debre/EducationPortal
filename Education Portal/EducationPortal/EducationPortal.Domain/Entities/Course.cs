using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Material> Materials { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
