namespace EducationPortal.Domain.Entities.Materials
{
    public class BookMaterial : Material
    {
        int NumberPages { get; set; }
        string Format { get; set; }
        string Author { get; set; }
        DateTime PublicationDate { get; set; }
    }
}
