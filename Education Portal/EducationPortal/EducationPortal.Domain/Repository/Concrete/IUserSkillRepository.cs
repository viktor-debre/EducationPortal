namespace EducationPortal.Domain.Repository
{
    public interface IUserSkillRepository
    {
        public List<UserSkill> Find();

        public void Update(UserSkill userSkill);
    }
}
