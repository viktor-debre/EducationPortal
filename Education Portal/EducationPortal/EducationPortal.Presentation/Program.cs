using EducationPortal.Presentation.Application;
using Microsoft.Extensions.DependencyInjection;

var root = CompositionRoot();

root.GetService<ConsoleApplication>()?.Run();

static IServiceProvider CompositionRoot()
{
    var services = new ServiceCollection();

    services.AddSingleton<ConsoleApplication>();

    EducationPortal.Infrastructure.DependencyInjection.RegisterFileSystemServices(services);
    EducationPortal.Application.DependencyInjection.RegisterApplicationServices(services);

    return services.BuildServiceProvider();
}