using EducationPortal.UI.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class MaterialView : BaseViewEntity
    {
        [Required(ErrorMessage = "Not specified name")]
        public string Name { get; set; }
    }
}
