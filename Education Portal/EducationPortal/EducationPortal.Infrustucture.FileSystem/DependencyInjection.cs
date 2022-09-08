using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Infrustucture.FileSystem.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterFileSystemServices(ServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
