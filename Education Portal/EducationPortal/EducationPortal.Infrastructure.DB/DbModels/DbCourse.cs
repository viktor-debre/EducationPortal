namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbCourse : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<DbMaterial>? Materials { get; set; }

        public ICollection<DbSkill> Skills { get; set; }
    }
}
