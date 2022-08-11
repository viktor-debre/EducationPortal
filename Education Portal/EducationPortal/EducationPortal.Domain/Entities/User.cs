namespace EducationPortal.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Material> Materials { get; set; }

        public List<Course> Courses { get; set; }
    }
}
