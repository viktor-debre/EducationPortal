using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class ArticleView : MaterialView
    {
        [Required(ErrorMessage = "Not specified sourse")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Not specified data")]
        public DateTime PublicationDate { get; set; }
    }
}
