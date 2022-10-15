namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbArticleMaterial : DbMaterial
    {
        public string Source { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
