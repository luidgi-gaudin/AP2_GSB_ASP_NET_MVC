using AP2_MVC_DOTNET.data;
using AP2_MVC_DOTNET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


 


var serverVersion = new MySqlServerVersion(new Version(11, 0, 2));


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
);
builder.Services.AddIdentity<Medecin, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;

        options.User.RequireUniqueEmail = true;
    }
).AddEntityFrameworkStores<ApplicationDbContext>();



// Configure authentication and change the default redirect paths
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    // Optionally, set other cookie options
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
});

var app = builder.Build();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();


app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();