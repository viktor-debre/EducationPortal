namespace EducationPortal.Application.Services
{
    internal class UserCourseSevice : IUserCourseService
    {
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Course> _courseRepository;

        public UserCourseSevice(IUserSkillRepository userSkillRepository,
                                IUserCourseRepository userCourseRepository,
                                IRepository<User> userRepository,
                                IRepository<Course> courseRepository)
        {
            _userSkillRepository = userSkillRepository;
            _userCourseRepository = userCourseRepository;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public List<Course> GetAvailableCourses(int userId)
        {
            var availableCourses = new List<Course>();
            var user = _userRepository.FindById(userId);
            foreach (var course in _courseRepository.Find())
            {
                if (user.Courses.FirstOrDefault(c => c.Id == course.Id) == null)
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
                var userCourse = _userCourseRepository.Find().FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
                if (userCourse.Status == "Started")
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
                var userCourse = _userCourseRepository.Find().FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
                if (userCourse.Status == "Passed")
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public void TakeCourse(Course course, int userId)
        {
            var userCourse = _userCourseRepository.Find().FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
            if (userCourse != null)
            {
                return;
            }

            var userAddedCourse = new UserCourse
            {
                UserId = userId,
                CourseId = course.Id,
                Status = "Started",
                PassPercent = FindPercentOfPassingCourse(course, userId)
            };

            _userCourseRepository.Add(userAddedCourse);
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

            user.Materials.Add(userPassedMaterial);
            _userRepository.Update(user);

            var userCourse = _userCourseRepository.Find().FirstOrDefault(x => x.UserId == userId && x.CourseId == course.Id);
            int passPercent = FindPercentOfPassingCourse(course, userId);
            userCourse.PassPercent = passPercent;
            if (passPercent == 100)
            {
                userCourse.Status = "Passed";
                PassCourse(course, userId);
            }

            _userCourseRepository.Update(userCourse);

            return true;
        }

        private void PassCourse(Course course, int userId)
        {
            var user = _userRepository.FindById(userId);

            foreach (var skill in course.Skills)
            {
                var userSkill = user.Skills.FirstOrDefault(s => s.Id == skill.Id);
                if (userSkill != null)
                {
                    var skillInDb = _userSkillRepository.Find().FirstOrDefault(x => x.UserId == userId && x.SkillId == course.Id);
                    skillInDb.Level++;
                    _userSkillRepository.Update(skillInDb);
                }
                else
                {
                    user.Skills.Add(skill);
                    var userAddedSkill = new UserSkill
                    {
                        UserId = userId,
                        SkillId = course.Id,
                        Level = 0
                    };

                    _userSkillRepository.Update(userAddedSkill);
                }
            }
        }

        private int FindPercentOfPassingCourse(Course course, int userId)
        {
            int result = 100;
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

            return result;
        }
    }
}
