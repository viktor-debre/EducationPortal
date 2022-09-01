namespace EducationPortal.Application.Services
{
    internal class UserCourseSevice : IUserCourseService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Course> _courseRepository;

        public UserCourseSevice(IRepository<User> userRepository, IRepository<Course> courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public List<Course> GetAvailableCourses(int userId)
        {
            var availableCourses = new List<Course>();
            var user = _userRepository.FindById(userId);
            foreach (var course in _courseRepository.Find())
            {
                if (user.UserCourses.FirstOrDefault(c => c.UserId == userId && c.CourseId == course.Id) == null)
                {
                    availableCourses.Add(course);
                }
            }

            return availableCourses;
        }

        public List<UserCourse> GetStartedCourses(int userId)
        {
            var user = _userRepository.FindById(userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = user.UserCourses.FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
                int passPercent = FindPercentOfPassingCourse(course, userId);
                userCourse.PassPercent = passPercent;
                _userRepository.Update(user);
                if (passPercent < 100)
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public List<UserCourse> GetPassedCourses(int userId)
        {
            var user = _userRepository.FindById(userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = user.UserCourses.FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
                if (userCourse.Status == "Passed")
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public void TakeCourse(Course course, int userId)
        {
            var user = _userRepository.FindById(userId);
            var userCourse = user.UserCourses.FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
            if (userCourse != null)
            {
                return;
            }

            int passPercent = FindPercentOfPassingCourse(course, userId);
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
            _userRepository.Update(user);
        }

        public bool PassMaterial(Course course, string nameMaterial, int userId)
        {
            var materialInCourse = course.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (materialInCourse == null)
            {
                return false;
            }

            var user = _userRepository.FindById(userId);
            var userPassedMaterial = user.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (userPassedMaterial != null)
            {
                return false;
            }

            user.Materials.Add(materialInCourse);
            _userRepository.Update(user);

            int passPercent = FindPercentOfPassingCourse(course, userId);
            var userCourse = user.UserCourses.FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
            userCourse.PassPercent = passPercent;
            _userRepository.Update(user);

            if (passPercent == 100)
            {
                userCourse.Status = "Passed";
                _userRepository.Update(user);
                PassCourse(course, userId);
            }

            return true;
        }

        public UserCourse? GetUserCoursesById(int userId, int courseId)
        {
            return _userRepository.FindById(userId).UserCourses.FirstOrDefault(x => x.UserId == userId && x.CourseId == courseId);
        }

        private void PassCourse(Course course, int userId)
        {
            foreach (var skill in course.Skills)
            {
                var user = _userRepository.FindById(userId);
                var userSkill = user.UserSkills.FirstOrDefault(x => x.UserId == userId && x.SkillId == skill.Id);
                if (userSkill != null)
                {
                    userSkill.Level++;
                    _userRepository.Update(user);
                }
                else
                {
                    var userAddedSkill = new UserSkill
                    {
                        UserId = userId,
                        SkillId = course.Id,
                        Level = 0
                    };

                    user.UserSkills.Add(userAddedSkill);
                    _userRepository.Update(user);
                }
            }
        }

        private int FindPercentOfPassingCourse(Course course, int userId)
        {
            int result = 0;
            int passedMaterialsNumber = 0;
            var userMaterials = _userRepository.FindById(userId).Materials;
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
