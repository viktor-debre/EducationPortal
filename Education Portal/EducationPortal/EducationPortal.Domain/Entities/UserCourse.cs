namespace EducationPortal.Domain.Entities
{
    public class UserCourse
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public string? Status { get; set; }

        public int? PassPercent { get; set; }
    }
}
