using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class VideoView : MaterialView
    {
        [Required(ErrorMessage = "Not specified duration")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "Not specified quality")]
        public string Quality { get; set; }
    }
}
