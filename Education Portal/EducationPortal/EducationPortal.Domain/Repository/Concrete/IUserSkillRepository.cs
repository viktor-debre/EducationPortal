namespace EducationPortal.Domain.Repository
{
    public interface IUserSkillRepository
    {
        public List<UserSkill> Find();

        public UserSkill FindById(int userId, int skillId);

        public void Update(UserSkill userSkill);
    }
}
