namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbVideoMaterial : DbMaterial
    {
        public TimeSpan Duration { get; set; }

        public string Quality { get; set; }
    }
}
