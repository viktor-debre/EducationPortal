using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Entities
{
    public class Course : BaseEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Material> Matherials { get; set; }
    }
}
