using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Infrastructure.DB.Repository.Concrete;
using EducationPortal.Infrastructure.DB.Repository.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure.DB
{
    public static class DependencyInjection
    {
        public static void RegisterDbServices(IServiceCollection services)
        {
            services.AddDbContext<PortalContext>()
                .AddScoped<IRepository<BookMaterial>, EntityRepository<BookMaterial, DbBookMaterial>>()
                .AddScoped<IRepository<VideoMaterial>, EntityRepository<VideoMaterial, DbVideoMaterial>>()
                .AddScoped<IRepository<ArticleMaterial>, EntityRepository<ArticleMaterial, DbArticleMaterial>>()
                .AddScoped<IRepository<Course>, CourseRepository>()
                .AddScoped<IRepository<Skill>, EntityRepository<Skill, DbSkill>>()
                .AddScoped<IRepository<User>, UserRepository>();
        }
    }
}
