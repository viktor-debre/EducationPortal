namespace EducationPortal.Infrastructure.DB.DbModels
{
    public class DbMaterial : DbBaseEntity
    {
        public string Name { get; set; }

        public ICollection<DbCourse> Courses { get; set; }

        public ICollection<DbUser> Users { get; set; }
    }
}
