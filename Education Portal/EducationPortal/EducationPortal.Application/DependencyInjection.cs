using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(ServiceCollection services)
        {
            services.AddSingleton<IUserAuthentication, UserAuthenticationService>()
                    .AddSingleton<IUserRegistration, UserRegistrationService>()
                    .AddSingleton<IMaterialManageService, MaterialManageService>()
                    .AddSingleton<ICourseService, CourseService>();
        }
    }
}
