namespace EducationPortal.Domain.Entities.Materials
{
    public class VideoMaterial : Material
    {
        public TimeSpan Duration { get; set; }
        public string Quality { get; set; }
    }
}
