using FLexElectronicsShop.Core;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Services.Interfaces;
using FLexElectronicsShop.Services;
using Microsoft.EntityFrameworkCore;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

ConfigurationServices(builder.Services);

var app = builder.Build();
await Seed.SeedUserAndRolesAsync(app);
Configure(app, app.Environment);

app.Run();

void ConfigurationServices(IServiceCollection services)
{
    services.AddSingleton<IPhotoService, PhotoService>();
    services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
    services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<FEShopContext>();

    services.AddMemoryCache();
    services.AddSession();
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

    services.AddDbContext<FEShopContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("FEShopContext") ??
        throw new InvalidOperationException("Connection string 'FEShopContext' not found.")));

    services.AddRazorPages();
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();
    app.UseEndpoints(x =>
    {
        x.MapRazorPages();
    });
}
