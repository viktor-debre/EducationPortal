using EducationPortal.UI.Models.Mapping;
using EducationPortal.UI.Services.Implementation;

namespace EducationPortal.UI
{
    public static class DependencyInjection
    {
        public static void RegisterUIServices(IServiceCollection services)
        {
            services.AddScoped<IUserInformationService, UserInformationService>()
                .AddScoped<IMapper, MapperForViewModels>();
        }
    }
}
