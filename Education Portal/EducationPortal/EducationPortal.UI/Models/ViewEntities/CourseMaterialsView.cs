using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseMaterialsView
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public MaterialView Material { get; set; }

        public List<SelectListItem> Materials { get; set; }
    }
}
