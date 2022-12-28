using EducationPortal.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.Application.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortalDb"));
            Infrastructure.DB.DependencyInjection.RegisterDbServices(services);
            Application.DependencyInjection.RegisterApplicationServices(services);            
        }
    }
}
