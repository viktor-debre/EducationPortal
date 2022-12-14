namespace EducationPortal.UI.Services.Interfaces
{
    public interface ICourseSelectListsService
    {
        public Task<CourseMaterialsView> GetAllMaterialsSelectList(int courseId);

        public Task<CourseSkillView> GetAllSkillsSelectList(int courseId);
    }
}
