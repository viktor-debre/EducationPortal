namespace EducationPortal.Domain.Entities
{
    public class Course
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Course> CourseList { get; set; }
    }
}
