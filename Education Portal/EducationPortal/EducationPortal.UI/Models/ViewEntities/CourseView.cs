namespace EducationPortal.Domain.Entities
{
    public class CourseView : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MaterialView> Materials { get; set; }

        public List<SkillView> Skills { get; set; }
    }
}
