using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterFileSystemServices(ServiceCollection services)
        {
            //services.AddSingleton<IRepository<User>, UserRepository>()
            //        .AddSingleton<IRepository<User>, BookRepository>()
            //        .AddSingleton<IRepository<User>, VideoRepository>()
            //        .AddSingleton<IRepository<User>, ArticleRepository>()
            //        .AddSingleton<IRepository<User>, CourceRepository>();
        }
    }
}
