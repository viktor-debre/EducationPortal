using EducationPortal.UI.Models.Mapping;
using EducationPortal.UI.Services.Implementation;
using EducationPortal.UI.Services.Interfaces;

namespace EducationPortal.UI
{
    public static class DependencyInjection
    {
        public static void RegisterUIServices(IServiceCollection services)
        {
            services.AddScoped<IUserInformationService, UserInformationService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<ISkillEditService, SkillEditService>()
                .AddScoped<IMaterialEditService, MaterialEditService>()
                .AddScoped<ICourseEditService, CourseEditService>()
                .AddScoped<IPassCourseService, PassCourseService>()
                .AddScoped<IUserCoursePassService, UserCoursePassService>()
                .AddScoped<ICourseSelectListsService, CourseSelectListService>()
                .AddScoped<IMapper, MapperForViewModels>();
        }
    }
}
