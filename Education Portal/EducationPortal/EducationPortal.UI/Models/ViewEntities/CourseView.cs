using EducationPortal.UI.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseView : BaseViewEntity
    {
        [Required(ErrorMessage = "Not specified name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Not specified description")]
        public string Description { get; set; }

        public List<MaterialView>? Materials { get; set; }

        public List<SkillView>? Skills { get; set; }
    }
}
