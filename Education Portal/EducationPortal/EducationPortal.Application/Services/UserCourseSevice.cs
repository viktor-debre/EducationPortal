namespace EducationPortal.Application.Services
{
    internal class UserCourseSevice : IUserCourseService
    {
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Material> _materialRepository;
        private readonly int _userId;

        public UserCourseSevice(IUserSkillRepository userSkillRepository,
                                IUserCourseRepository userCourseRepository,
                                IRepository<User> userRepository,
                                IRepository<Course> courseRepository,
                                IRepository<Material> materialRepository,
                                int userId)
        {
            _userSkillRepository = userSkillRepository;
            _userCourseRepository = userCourseRepository;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _userId = userId;
        }

        public List<Course> GetAvailableCourses()
        {
            return _courseRepository.Find();
        }

        public List<UserCourse> GetStartedCourses()
        {
            var user = _userRepository.FindById(_userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = _userCourseRepository.FindById(_userId, course.Id);
                if (userCourse.Status == "Started")
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public List<UserCourse> GetPassedCourses()
        {
            var user = _userRepository.FindById(_userId);
            List<UserCourse> courses = new List<UserCourse>();

            foreach (var course in user.Courses)
            {
                var userCourse = _userCourseRepository.FindById(_userId, course.Id);
                if (userCourse.Status == "Passed")
                {
                    courses.Add(userCourse);
                }
            }

            return courses;
        }

        public void TakeCourse(Course course)
        {
            var userCourse = _userCourseRepository.FindById(_userId, course.Id);
            if (userCourse != null)
            {
                return;
            }

            var user = _userRepository.FindById(_userId);
            user.Courses.Add(course);
            _userRepository.Update(user);

            var userAddedCourse = new UserCourse
            {
                UserId = _userId,
                CourseId = course.Id,
                Status = "Started",
                PassPercent = FindPercentOfPassingCourse(course)
            };

            _userCourseRepository.Update(userAddedCourse);
        }

        public bool PassMaterial(Course course, string nameMaterial)
        {
            var materialInCourse = course.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (materialInCourse == null)
            {
                return false;
            }

            var user = _userRepository.FindById(_userId);
            var userPassedMaterial = user.Materials.FirstOrDefault(m => m.Name == nameMaterial);
            if (userPassedMaterial != null)
            {
                return false;
            }

            user.Materials.Add(userPassedMaterial);
            _userRepository.Update(user);

            var userCourse = _userCourseRepository.FindById(_userId, course.Id);
            int passPercent = FindPercentOfPassingCourse(course);
            userCourse.PassPercent = passPercent;
            if (passPercent == 100)
            {
                userCourse.Status = "Passed";
                PassCourse(course);
            }

            _userCourseRepository.Update(userCourse);

            return true;
        }

        public void PassCourse(Course course)
        {
            var user = _userRepository.FindById(_userId);

            foreach (var skill in course.Skills)
            {
                var userSkill = user.Skills.FirstOrDefault(s => s.Id == skill.Id);
                if (userSkill != null)
                {
                    var skillInDb = _userSkillRepository.FindById(_userId, skill.Id);
                    skillInDb.Level++;
                    _userSkillRepository.Update(skillInDb);
                }
                else
                {
                    user.Skills.Add(skill);
                    var userAddedSkill = new UserSkill
                    {
                        UserId = _userId,
                        SkillId = course.Id,
                        Level = 0
                    };

                    _userSkillRepository.Update(userAddedSkill);
                }
            }
        }

        private int FindPercentOfPassingCourse(Course course)
        {
            int result = 100;
            int passedMaterialsNumber = 0;
            var userMaterials = _userRepository.FindById(_userId).Materials;
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
