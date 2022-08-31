using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.Repository.Concrete;
using EducationPortal.Infrastructure.DB.Repository.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Infrastructure.DB
{
    public static class DependencyInjection
    {
        public static void RegisterDbServices(ServiceCollection services)
        {
            services.AddDbContext<PortalContext>()
                .AddTransient<IRepository<BookMaterial>, EntityRepository<BookMaterial, DbBookMaterial>>()
                .AddTransient<IRepository<VideoMaterial>, EntityRepository<VideoMaterial, DbVideoMaterial>>()
                .AddTransient<IRepository<ArticleMaterial>, EntityRepository<ArticleMaterial, DbArticleMaterial>>()
                .AddSingleton<IRepository<Course>, CourseRepository>()
                .AddTransient<IRepository<Skill>, EntityRepository<Skill, DbSkill>>()
                .AddTransient<IRepository<User>, UserRepository>()
                .AddTransient<IUserSkillRepository, UserSkillRepository>()
                .AddTransient<IUserCourseRepository, UserCourseRepository>();
        }
    }
}
