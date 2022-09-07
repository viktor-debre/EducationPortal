namespace EducationPortal.UI.Models.ViewEntities
{
    internal class BookView : MaterialView
    {
        public int NumberPages { get; set; }

        public string Format { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
