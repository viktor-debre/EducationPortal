namespace EducationPortal.Domain.Entities.Materials
{
    public class VideoMaterial : Material
    {
        TimeSpan Duration { get; set; }
        string Quality { get; set; }
    }
}
