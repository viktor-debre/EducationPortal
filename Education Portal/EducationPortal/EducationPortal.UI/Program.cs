using EducationPortal.Infrastructure.DB;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependencyInjection.RegisterDbServices(builder.Services);

//EducationPortal.Infrastructure.DependencyInjection.RegisterFileSystemServices(builder.Services);
string connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionStrings");

builder.Services.AddDbContext<PortalContext>(options => options.UseSqlServer(connectionString));
EducationPortal.Application.DependencyInjection.RegisterApplicationServices(builder.Services);
EducationPortal.UI.DependencyInjection.RegisterUIServices(builder.Services);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
