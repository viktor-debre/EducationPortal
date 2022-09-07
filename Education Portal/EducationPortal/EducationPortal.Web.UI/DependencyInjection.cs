using EducationPortal.Web.UI.Models.Mapping;
using EducationPortal.Web.UI.Services.Implementation;

namespace EducationPortal.Web.UI
{
    public static class DependencyInjection
    {
        public static void RegisterUIServices(IServiceCollection services)
        {
            services.AddSingleton<IUserInformationService, UserInformationService>()
                .AddSingleton<IMapper, MapperForViewModels>();
        }
    }
}
