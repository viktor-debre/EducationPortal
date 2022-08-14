using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterFileSystemServices(ServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>()
                    .AddSingleton<IBookRepository, BookRepository>()
                    .AddSingleton<IVideoRepository, VideoRepository>()
                    .AddSingleton<IArticleRepository, ArticleRepository>()
                    .AddSingleton<ICourseRepository, CourceRepository>();
        }
    }
}
