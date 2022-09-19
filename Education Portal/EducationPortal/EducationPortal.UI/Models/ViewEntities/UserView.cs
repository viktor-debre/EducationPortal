using EducationPortal.UI.Models.Common;

namespace EducationPortal.UI.Models.ViewEntities
{
    public class UserView : BaseViewEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public List<MaterialView> Materials { get; set; }

        public List<SkillView> Skills { get; set; }

        public List<CourseView> Courses { get; set; }

        public List<UserCourseView> UserCourses { get; set; }

        public List<UserSkillView> UserSkills { get; set; }
    }
}
