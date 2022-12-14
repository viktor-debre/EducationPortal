namespace EducationPortal.Infrastructure.DB.DbModels
{
    public class DbUserCourse
    {
        public int UserId { get; set; }

        public DbUser User { get; set; }

        public int CourseId { get; set; }

        public DbCourse Course { get; set; }

        public string Status { get; set; }

        public int PassPercent { get; set; }
    }
}
