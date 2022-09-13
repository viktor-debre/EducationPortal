using EducationPortal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IMaterialManageService, MaterialManageService>()
                    .AddScoped<ICourseService, CourseService>()
                    .AddScoped<ISkillService, SkillService>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IUserInfoService, UserInfoService>()
                    .AddScoped<IUserCourseService, UserCourseSevice>();
        }
    }
}
