using EducationPortal.UI.Models.Common;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseView : BaseViewEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MaterialView> Materials { get; set; }

        public List<SkillView> Skills { get; set; }
    }
}
