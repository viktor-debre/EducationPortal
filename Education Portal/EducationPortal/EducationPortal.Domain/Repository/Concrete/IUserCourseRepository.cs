namespace EducationPortal.Domain.Repository
{
    public interface IUserCourseRepository
    {
        public List<UserCourse> Find();

        public UserCourse FindById(int userId, int courseId);

        public void Update(UserCourse userCourse);
    }
}
