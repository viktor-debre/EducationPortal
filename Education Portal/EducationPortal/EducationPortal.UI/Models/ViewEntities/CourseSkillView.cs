using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseSkillView
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public List<SelectListItem> Skills { get; set; }

        public List<int> SkillId { get; set; }
    }
}
