namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbCourse : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<DbMaterial> Materials { get; set; }
    }
}
