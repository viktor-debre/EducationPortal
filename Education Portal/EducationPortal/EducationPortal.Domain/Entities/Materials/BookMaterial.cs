namespace EducationPortal.Domain.Entities.Materials
{
    public class BookMaterial : Material
    {
        public int NumberPages { get; set; }
        public string Format { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
