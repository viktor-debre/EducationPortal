using EducationPortal.Domain.Entities;

namespace EducationPortal.UI.Models.Mapping
{
    public interface IMapper
    {
        public UserView MapUserToViewModel(User user);

        public User MapUserToDomainModel(UserView user);

        public MaterialView MapMaterialToViewModel(Material material);

        public Material MapMaterialToDomainModel(MaterialView material);

        public SkillView MapSkillToViewModel(Skill skill);

        public Skill MapSkillToDomainModel(SkillView skill);

        public UserSkillView MapUserSkillToViewModel(UserSkill userSkill);

        public UserSkill MapUserSkillToDomainModel(UserSkillView userSkill);

        public CourseView MapCourseToViewModel(Course course);

        public Course MapCourseToDomainModel(CourseView course);

        public UserCourseView MapUserCourseToViewModel(UserCourse userCourse);

        public UserCourse MapUserCourseToDomainModel(UserCourseView userCourse);
    }
}
