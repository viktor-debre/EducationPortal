using EducationPortal.UI.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class SkillView : BaseViewEntity
    {
        [Required(ErrorMessage = "Not specified title")]
        public string Title { get; set; }
    }
}
