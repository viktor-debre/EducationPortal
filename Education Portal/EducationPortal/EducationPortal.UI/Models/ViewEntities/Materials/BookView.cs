using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class BookView : MaterialView
    {
        [Required(ErrorMessage = "Not specified number of pages")]
        public int NumberPages { get; set; }

        [Required(ErrorMessage = "Not specified format")]
        public string Format { get; set; }

        [Required(ErrorMessage = "Not specified author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Not specified publication date")]
        public DateTime PublicationDate { get; set; }
    }
}
