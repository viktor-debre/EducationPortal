using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class UserCoursesManager
    {
        private readonly IUserCourseService _userCourseService;
        private readonly ICourseService _courseService;
        private readonly IUserInfoService _userSkillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public UserCoursesManager(IUserCourseService userCourse, ICourseService courseService, IUserInfoService userSkillService)
        {
            _userCourseService = userCourse;
            _courseService = courseService;
            _userSkillService = userSkillService;
        }

        public void PassingCoursesMenu(int userId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuStrings.USER_COURSES_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "1":
                        ViewAvailableCourses(userId);
                        break;
                    case "2":
                        ViewStartedCourses(userId);
                        break;
                    case "3":
                        ViewPassedCourses(userId);
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void ViewPassedCourses(int userId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Passed courses:");
                var courses = _userCourseService.GetPassedCourses(userId);

                foreach (var course in courses)
                {
                    var passesCourse = _courseService.GetCourses().FirstOrDefault(x => x.Id == course.CourseId);
                    Console.WriteLine($"---<{course.CourseId}>---");
                    Console.WriteLine($"Name: {passesCourse.Name} status: {course.Status} percent: {course.PassPercent}");
                    OutputMaterials(passesCourse, userId);
                    OutputSkills(passesCourse, userId);
                }

                Console.WriteLine(MenuStrings.PASSED_COURSES_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void ViewStartedCourses(int userId)
        {
            while (true)
            {
                var courses = _userCourseService.GetStartedCourses(userId);
                Console.Clear();
                Console.WriteLine("Started courses:");
                foreach (var course in courses)
                {
                    var startedCourse = _courseService.GetCourseById(course.CourseId);
                    Console.WriteLine($"---<{course.CourseId}>---");
                    Console.WriteLine($"Name: {startedCourse.Name} status: {course.Status} percent: {course.PassPercent}");
                    OutputMaterials(startedCourse, userId);
                    OutputSkills(startedCourse, userId);
                }

                Console.WriteLine(MenuStrings.PASSING_COURSE_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "start":
                        int courseId;
                        if (_inputHandler.TryInputIntValue(out courseId, "course id", Operation.PASSING, EntityName.USER_COURSE))
                        {
                            var existingCourse = _courseService.GetCourseById(courseId);
                            if (existingCourse != null)
                            {
                                PassMaterialInCourse(existingCourse, userId);
                            }
                        }

                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }

                Console.WriteLine(MenuStrings.PASSING_COURSE_MENU);
            }
        }

        private void ViewAvailableCourses(int userId)
        {
            while (true)
            {
                var courses = _userCourseService.GetAvailableCourses(userId);
                Console.Clear();
                Console.WriteLine("Available courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"---<{course.Id}>---");
                    Console.WriteLine($"Name: {course.Name} description: {course.Description}");
                    OutputMaterials(course, userId);
                    OutputSkills(course, userId);
                }

                Console.WriteLine(MenuStrings.AVAILABLE_COURSES_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "take":
                        int courseId;
                        if (_inputHandler.TryInputIntValue(out courseId, "course id", Operation.TAKING, EntityName.USER_COURSE))
                        {
                            var existingCourse = _courseService.GetCourses().FirstOrDefault(x => x.Id == courseId);
                            if (existingCourse != null)
                            {
                                _userCourseService.TakeCourse(existingCourse, userId);
                            }
                        }

                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void PassMaterialInCourse(Course course, int userId)
        {
            while (true)
            {
                Console.Clear();
                var startedCourse = _userCourseService.GetUserCoursesById(userId, course.Id);
                Console.WriteLine($"---<{startedCourse.CourseId}>---");
                Console.WriteLine($"Name: {course.Name} status: {startedCourse.Status} percent: {startedCourse.PassPercent}");
                OutputMaterials(course, userId);
                OutputSkills(course, userId);
                Console.WriteLine(MenuStrings.PASSING_MATERIAL_IN_COURSE_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "pass":
                        string materialName;
                        if (_inputHandler.TryInputStringValue(out materialName, "material name", Operation.PASSING, EntityName.USER_COURSE))
                        {
                            _userCourseService.PassMaterial(course, materialName, userId);
                        }

                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void OutputMaterials(Course course, int userId)
        {
            var user = _userSkillService.GetUserById(userId);
            Console.WriteLine("Materials:");
            foreach (var material in course.Materials)
            {
                string passed = "";
                if (user.Materials.FirstOrDefault(m => m.Id == material.Id) != null)
                {
                    passed = $"passed";
                }
                else
                {
                    passed = "not passed";
                }

                Console.WriteLine($"Name: {material.Name} status: {passed}");
            }
        }

        private void OutputSkills(Course course, int userId)
        {
            var user = _userSkillService.GetUserById(userId);
            Console.WriteLine("Skills:");
            foreach (var skill in course.Skills)
            {
                int level = 0;
                UserSkill? userSkill = user.UserSkills.FirstOrDefault(s => s.SkillId == skill.Id && s.UserId == userId);
                if (userSkill != null)
                {
                    level = userSkill.Level;
                }

                Console.WriteLine($"Title: {skill.Title} with your level: {level}");
            }
        }
    }
}
