using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Domain.Entities
{
    public class Course
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Material> Matherials { get; set; }
    }
}
