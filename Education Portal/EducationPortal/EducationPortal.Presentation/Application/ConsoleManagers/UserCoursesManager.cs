namespace EducationPortal.Presentation.Application
{
    internal class UserCoursesManager
    {
        private readonly IUserCourseService _userCourseService;
        private readonly ICourseService _courseService;
        private readonly IUserInfoService _userSkillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public UserCoursesManager(
            IUserCourseService userCourse,
            ICourseService courseService,
            IUserInfoService userSkillService
        )
        {
            _userCourseService = userCourse;
            _courseService = courseService;
            _userSkillService = userSkillService;
        }

        public async Task PassingCoursesMenu(int userId)
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
                        await ViewAvailableCourses(userId);
                        break;
                    case "2":
                        await ViewStartedCourses(userId);
                        break;
                    case "3":
                        await ViewPassedCourses(userId);
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task ViewPassedCourses(int userId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Passed courses:");
                var courses = await _userCourseService.GetPassedCourses(userId);

                foreach (var course in courses)
                {
                    var passesCourse = await _courseService.GetCourseById(course.CourseId);
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

        private async Task ViewStartedCourses(int userId)
        {
            while (true)
            {
                var courses = await _userCourseService.GetStartedCourses(userId);
                Console.Clear();
                Console.WriteLine("Started courses:");
                foreach (var course in courses)
                {
                    var startedCourse = await _courseService.GetCourseById(course.CourseId);
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
                            var existingCourse = await _courseService.GetCourseById(courseId);
                            if (existingCourse != null)
                            {
                                await PassMaterialInCourse(existingCourse, userId);
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

        private async Task ViewAvailableCourses(int userId)
        {
            while (true)
            {
                var courses = await _userCourseService.GetAvailableCourses(userId);
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
                            var existingCourse = await _courseService.GetCourseById(courseId);
                            if (existingCourse != null)
                            {
                                await _userCourseService.TakeCourse(existingCourse, userId);
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

        private async Task PassMaterialInCourse(Course course, int userId)
        {
            while (true)
            {
                Console.Clear();
                var startedCourse = await _userCourseService.GetUserCoursesById(userId, course.Id);
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
                            await _userCourseService.PassMaterial(course, materialName, userId);
                        }

                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task OutputMaterials(Course course, int userId)
        {
            var user = await _userSkillService.GetUserById(userId);
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

        private async Task OutputSkills(Course course, int userId)
        {
            var user = await _userSkillService.GetUserById(userId);
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
