namespace EducationPortal.UI.Models.ViewEntities
{
    public class CourseView
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MaterialView> Materials { get; set; }

        public List<SkillView> Skills { get; set; }
    }
}
