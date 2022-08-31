namespace EducationPortal.Presentation.Application
{
    internal class UserCoursesManager
    {
        private readonly IUserCourseService _userCourse;
        private readonly ICourseService _courseService;

        public UserCoursesManager(IUserCourseService userCourse, ICourseService courseService)
        {
            _userCourse = userCourse;
            _courseService = courseService;
        }

        public void PassingCourses(int userId)
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
                        ViewAvailableCourses();
                        break;
                    case "2":
                        PassCourses(userId);
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
                var courses = _userCourse.GetPassedCourses(userId);

                foreach (var course in courses)
                {
                    var passesCourse = _courseService.GetCourses().FirstOrDefault(x => x.Id == course.CourseId);
                    Console.WriteLine($"Passed course name: {passesCourse.Name} status: {course.Status} percent: {course.PassPercent}");
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

        private void PassCourses(int userId)
        {
            var list = _userCourse.GetStartedCourses(userId);
        }

        private void ViewAvailableCourses()
        {
            var list = _userCourse.GetAvailableCourses();
        }
    }
}
