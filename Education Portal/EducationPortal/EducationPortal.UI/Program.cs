var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
EducationPortal.Infrastructure.DB.DependencyInjection.RegisterDbServices(builder.Services);

//EducationPortal.Infrastructure.DependencyInjection.RegisterFileSystemServices(services);

EducationPortal.Application.DependencyInjection.RegisterApplicationServices(builder.Services);
EducationPortal.UI.DependencyInjection.RegisterUIServices(builder.Services);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
