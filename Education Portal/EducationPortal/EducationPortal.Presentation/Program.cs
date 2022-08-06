using EducationPortal.Presentation.Application;
using Microsoft.Extensions.DependencyInjection;

var _root = CompositionRoot();
_root.GetService<ConsoleApplication>()?.Run();

static IServiceProvider CompositionRoot()
{
    var services = new ServiceCollection();

    services.AddSingleton<ConsoleApplication>();

    //My declaration
    EducationPortal.Application.DependencyInjection.RegisterApplicationServices(services);

    //My declaration

    return services.BuildServiceProvider();
}