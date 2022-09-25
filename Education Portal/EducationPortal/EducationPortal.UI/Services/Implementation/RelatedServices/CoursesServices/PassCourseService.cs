using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class PassCourseService : IPassCourseService
    {
        private readonly IUserCourseService _userCourse;
        private readonly IMapper _mapper;

        public PassCourseService(IUserCourseService userCourse, IMapper mapper)
        {
            _userCourse = userCourse;
            _mapper = mapper;
        }

        public async Task<List<CourseView>> GetAvailableCourses(int userId)
        {
            List<CourseView> courses = new List<CourseView>();
            var coursesInDb = await _userCourse.GetAvailableCourses(userId);
            foreach (var course in coursesInDb)
            {
                courses.Add(_mapper.MapCourseToViewModel(course));
            }

            return courses;
        }

        public async Task<List<UserCourseView>> GetPassedCourses(int userId)
        {
            List<UserCourseView> courses = new List<UserCourseView>();
            foreach (var course in await _userCourse.GetPassedCourses(userId))
            {
                courses.Add(_mapper.MapUserCourseToViewModel(course));
            }

            return courses;
        }

        public async Task<List<UserCourseView>> GetStartedCourses(int userId)
        {
            List<UserCourseView> courses = new List<UserCourseView>();
            foreach (var course in await _userCourse.GetStartedCourses(userId))
            {
                courses.Add(_mapper.MapUserCourseToViewModel(course));
            }

            return courses;
        }

        public async Task<UserCourseView> GetUserCoursesById(int userId, int courseId)
        {
            return _mapper.MapUserCourseToViewModel(await _userCourse.GetUserCoursesById(userId, courseId));
        }

        public async Task<bool> PassMaterial(CourseView course, string nameMaterial, int userId)
        {
            return await _userCourse.PassMaterial(_mapper.MapCourseToDomainModel(course), nameMaterial, userId);
        }

        public async Task TakeCourse(CourseView course, int userId)
        {
            await _userCourse.TakeCourse(_mapper.MapCourseToDomainModel(course), userId);
        }
    }
}
