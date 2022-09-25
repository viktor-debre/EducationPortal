using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Services.Implementation
{
    public class UserCoursePassService : IUserCoursePassService
    {
        private readonly IPassCourseService _userPassCourse;
        private readonly IUserInformationService _userInformation;
        private readonly ICourseEditService _courseEditService;

        public UserCoursePassService(IPassCourseService userPassCourse, IUserInformationService userInformation, ICourseEditService courseEditService)
        {
            _userPassCourse = userPassCourse;
            _userInformation = userInformation;
            _courseEditService = courseEditService;
        }

        public async Task<List<CourseView>> AvailableCourses(string userName)
        {
            var user = await _userInformation.GetUserInfo(userName);
            return await _userPassCourse.GetAvailableCourses(user.Id);
        }

        public async Task<List<CourseView>> StartedCourses(string userName)
        {
            var coursesInDb = await _courseEditService.GetCourses();
            var startedCourses = await StartedCoursesGetStatusInfo(userName);
            List<CourseView> courses = new List<CourseView>();
            foreach (var course in startedCourses)
            {
                var item = coursesInDb.FirstOrDefault(x => x.Id == course.CourseId);
                if (item != null)
                {
                    courses.Add(item);
                }
            }

            return courses;
        }

        public async Task<List<UserCourseView>> StartedCoursesGetStatusInfo(string userName)
        {
            var user = await _userInformation.GetUserInfo(userName);
            var startedCourses = await _userPassCourse.GetStartedCourses(user.Id);
            return startedCourses;
        }

        public async Task TakeCourse(int? courseId, string userName)
        {
            if (courseId == null)
            {
                return;
            }

            int id = (int)courseId;
            var course = await _courseEditService.GetByIdCourse(id);
            var user = await _userInformation.GetUserInfo(userName);
            await _userPassCourse.TakeCourse(course, user.Id);
        }

        public async Task PassMaterial(int? courseId, string? materialName, string userName)
        {
            var user = await _userInformation.GetUserInfo(userName);
            if (courseId != null && materialName != null)
            {
                var course = await _courseEditService.GetByIdCourse((int)courseId);
                await _userPassCourse.PassMaterial(course, materialName, user.Id);
            }
        }

        public async Task<List<CourseView>> PassedCourses(string userName)
        {
            var user = await _userInformation.GetUserInfo(userName);
            var passedCourses = await _userPassCourse.GetPassedCourses(user.Id);
            List<CourseView> courses = new List<CourseView>();
            foreach (var course in await _courseEditService.GetCourses())
            {
                var findedCourse = passedCourses.FirstOrDefault(x => x.CourseId == course.Id);
                if (findedCourse != null)
                {
                    courses.Add(course);
                }
            }

            return courses;
        }

        public async Task<CourseView> GetCourseToPass(int? courseId)
        {
            return await _courseEditService.GetByIdCourse((int)courseId);
        }

        public async Task<List<MaterialView>> PassedMaterials(int? courseId, string userName)
        {
            var course = await _courseEditService.GetByIdCourse((int)courseId);
            List<MaterialView> materials = new List<MaterialView>();
            var user = await _userInformation.GetUserInfo(userName);
            foreach (var item in course.Materials)
            {
                materials.Add(user.Materials.FirstOrDefault(x => x.Id == item.Id));
            }

            return materials;
        }
    }
}
