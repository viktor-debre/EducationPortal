using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Repository;
using EducationPortal.Infrastructure.DB.Repository.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure.DB
{
    public static class DependencyInjection
    {
        public static void RegisterDbServices(ServiceCollection services)
        {
            services.AddDbContext<PortalContext>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IBookRepository, BookRepository>()
                .AddSingleton<IVideoRepository, VideoRepository>()
                .AddSingleton<IArticleRepository, ArticleRepository>()
                .AddSingleton<ICourseRepository, CourseRepository>()
                .AddSingleton<IRepository<Skill>, EntityRepository<Skill, DbSkill>>();
        }
    }
}
