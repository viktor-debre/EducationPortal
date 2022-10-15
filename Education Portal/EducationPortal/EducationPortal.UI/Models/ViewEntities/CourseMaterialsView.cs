using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseMaterialsView
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public List<SelectListItem> Materials { get; set; }

        public List<int> MaterialsId { get; set; }
    }
}
