namespace EducationPortal.Infrastructure.DB.DbModels.Materials
{
    internal class DbArticleMaterial : DbMaterial
    {
        public string Source { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
