using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddSingleton<IMaterialManageService, MaterialManageService>()
                    .AddSingleton<ICourseService, CourseService>()
                    .AddSingleton<ISkillService, SkillService>()
                    .AddSingleton<IUserService, UserService>()
                    .AddSingleton<IUserInfoService, UserInfoService>()
                    .AddSingleton<IUserCourseService, UserCourseSevice>();
        }
    }
}
