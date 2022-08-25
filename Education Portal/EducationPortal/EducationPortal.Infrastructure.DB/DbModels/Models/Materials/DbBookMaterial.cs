namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbBookMaterial : DbMaterial
    {
        public int NumberPages { get; set; }

        public string Format { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
