using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Repository.Concrete;
using EducationPortal.Infrastructure.DB.Repository.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure.DB
{
    public static class DependencyInjection
    {
        public static void RegisterDbServices(IServiceCollection services)
        {
            services.AddSingleton<PortalContext>()
                .AddSingleton<IRepository<BookMaterial>, EntityRepository<BookMaterial, DbBookMaterial>>()
                .AddSingleton<IRepository<VideoMaterial>, EntityRepository<VideoMaterial, DbVideoMaterial>>()
                .AddSingleton<IRepository<ArticleMaterial>, EntityRepository<ArticleMaterial, DbArticleMaterial>>()
                .AddSingleton<IRepository<Course>, CourseRepository>()
                .AddSingleton<IRepository<Skill>, EntityRepository<Skill, DbSkill>>()
                .AddSingleton<IRepository<User>, UserRepository>();
        }
    }
}
