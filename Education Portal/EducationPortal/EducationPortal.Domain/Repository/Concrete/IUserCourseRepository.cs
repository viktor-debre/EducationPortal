namespace EducationPortal.Domain.Repository
{
    public interface IUserCourseRepository
    {
        public List<UserCourse> Find();

        public void Add(UserCourse userCourse);

        public void Update(UserCourse userCourse);
    }
}
