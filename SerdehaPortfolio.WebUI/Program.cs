using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Context;
using SerdehaPortfolio.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllersWithViews();
services.AddRazorPages().AddRazorRuntimeCompilation();
services.AddDbContext<SerdehaPortfolioDbContext>();
services.AddIdentity<AuthorUser, AuthorRole>().AddEntityFrameworkStores<SerdehaPortfolioDbContext>();
services.AddMyServices();

var app = builder.Build();

app.UseStaticFiles();



//app.MapAreaControllerRoute(
//    name: "Admin",
//    areaName: "Admin",
//    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
//);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}",
    defaults: new { Controller = "Default", Action = "Index" }
);


app.Run();