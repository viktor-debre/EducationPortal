using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterFileSystemServices(ServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
