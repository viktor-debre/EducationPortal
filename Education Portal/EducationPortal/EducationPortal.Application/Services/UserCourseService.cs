using EducationPortal.Domain.Entities;

namespace EducationPortal.Application.Services
{
    internal class UserCourseService : IUserCourseService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Course> _courseRepository;

        public UserCourseService(IRepository<User> userRepository, IRepository<Course> courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAvailableCourses(int userId)
        {
            var availableCourses = new List<Course>();
            var user = await _userRepository.FindById(userId);
            foreach (var course in await _courseRepository.Find())
            {
                if (user.UserCourses.FirstOrDefault(c => c.CourseId == course.Id) == null)
                {
                    availableCourses.Add(course);
                }
            }

            return availableCourses;
        }

        public async Task<List<UserCourse>> GetStartedCourses(int userId)
        {
            var user = await _userRepository.FindById(userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = user.UserCourses.FirstOrDefault(x => x.CourseId == course.Id);
                int passPercent = await FindPercentOfPassingCourse(course, userId);
                userCourse.PassPercent = passPercent;
                await _userRepository.Update(user);
                if (passPercent < 100)
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public async Task<List<UserCourse>> GetPassedCourses(int userId)
        {
            var user = await _userRepository.FindById(userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = user.UserCourses.FirstOrDefault(x => x.CourseId == course.Id);
                if (userCourse.Status == "Passed")
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public async Task TakeCourse(Course course, int userId)
        {
            var user = await _userRepository.FindById(userId);
            var userCourse = user.UserCourses.FirstOrDefault(x => x.CourseId == course.Id);
            if (userCourse != null)
            {
                return;
            }

            int passPercent = await FindPercentOfPassingCourse(course, userId);
            UserCourse userAddedCourse = new UserCourse
            {
                UserId = userId,
                CourseId = course.Id
            };
            if (passPercent == 100)
            {
                userAddedCourse.Status = "Passed";
            }
            else
            {
                userAddedCourse.Status = "Started";
            }

            userAddedCourse.PassPercent = passPercent;
            user.UserCourses.Add(userAddedCourse);
            await _userRepository.Update(user);
        }

        public async Task<bool> PassMaterial(Course course, string nameMaterial, int userId)
        {
            var materialInCourse = course.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (materialInCourse == null)
            {
                return false;
            }

            var user = await _userRepository.FindById(userId);
            var userPassedMaterial = user.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (userPassedMaterial != null)
            {
                return false;
            }

            user.Materials.Add(materialInCourse);
            await _userRepository.Update(user);

            int passPercent = await FindPercentOfPassingCourse(course, userId);
            var userCourse = user.UserCourses.FirstOrDefault(x => x.CourseId == course.Id);
            userCourse.PassPercent = passPercent;
            await _userRepository.Update(user);

            if (passPercent == 100)
            {
                userCourse.Status = "Passed";
                await _userRepository.Update(user);
                await PassCourse(course, userId);
            }

            return true;
        }

        public async Task<UserCourse?> GetUserCoursesById(int userId, int courseId)
        {
            var user = await _userRepository.FindById(userId);
            return user.UserCourses.FirstOrDefault(x => x.CourseId == courseId);
        }

        private async Task PassCourse(Course course, int userId)
        {
            var user = await _userRepository.FindById(userId);
            foreach (var skill in course.Skills)
            {
                var userSkill = user.UserSkills.FirstOrDefault(x => x.SkillId == skill.Id);
                if (userSkill != null)
                {
                    userSkill.Level++;
                }
                else
                {
                    var userAddedSkill = new UserSkill
                    {
                        UserId = userId,
                        SkillId = skill.Id,
                        Level = 1
                    };

                    user.UserSkills.Add(userAddedSkill);
                }

                await _userRepository.Update(user);
            }
        }

        private async Task<int> FindPercentOfPassingCourse(Course course, int userId)
        {
            int result = 0;
            int passedMaterialsNumber = 0;
            var user = await _userRepository.FindById(userId);
            var userMaterials = user.Materials;
            foreach (var material in course.Materials)
            {
                if (userMaterials.FirstOrDefault(m => m.Id == material.Id) != null)
                {
                    passedMaterialsNumber++;
                }
            }

            if (course.Materials.Count != 0)
            {
                result = 100 * passedMaterialsNumber / course.Materials.Count;
            }
            else
            {
                result = 100;
            }

            return result;
        }
    }
}