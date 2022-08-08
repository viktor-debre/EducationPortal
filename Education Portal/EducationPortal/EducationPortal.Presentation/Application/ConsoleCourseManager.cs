namespace EducationPortal.Presentation.Application
{
    internal class ConsoleCourseManager
    {
        ICourseService _courseService;

        public ConsoleCourseManager(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void EditCources()
        {

        }
    }
}
