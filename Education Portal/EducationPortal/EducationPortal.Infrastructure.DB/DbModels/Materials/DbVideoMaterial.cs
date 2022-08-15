namespace EducationPortal.Infrastructure.DB.DbModels.Materials
{
    internal class DbVideoMaterial : DbMaterial
    {
        public TimeSpan Duration { get; set; }

        public string Quality { get; set; }
    }
}
