using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.DataAccess;
using MyProject.Services;
using Stripe;
using System;
using MyProject_L00194748.Pages.PageViewModels;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MangaShopDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MangaShopDBContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
string key = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
StripeConfiguration.ApiKey = key;
app.UseAuthorization();

app.MapRazorPages();
await app.CreateRolesAsync(builder.Configuration);

app.Run();
public static class WebApplicationExtensions
{
    public static async Task<WebApplication> CreateRolesAsync(this WebApplication app, IConfiguration configuration)
    {
        using var scope = app.Services.CreateScope();
        var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));
        var userManager = scope.ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
        var roles = configuration.GetSection("Roles").Get<List<String>>();
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var adminEmail = configuration["SeedAdmin:Email"] ?? "admin@gmail.ie";
        var adminPassword = configuration["SeedAdmin:Password"] ?? "Admin123!";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (!result.Succeeded)
            {
                // optional: log errors
                return app;
            }
        }
        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        return app;

    }
}

