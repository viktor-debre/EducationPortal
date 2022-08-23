using EducationPortal.Infrastructure.DB.DbModels.Common;

namespace EducationPortal.Infrastructure.DB.DbModels.Materials
{
    internal class DbMaterial : DbBaseEntity
    {
        public string Name { get; set; }

        public ICollection<DbCourse> Courses { get; set; }
    }
}
