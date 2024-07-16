using NetworkMonitoring.Application.Helper;
using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Application.Infrastracture.Account;
using NetworkMonitoring.Application.Repository.Account;
using NetworkMonitoring.Database.DBC;
using System.Globalization;
using NetworkMonitoring.Application.Infrastracture.BasicData;
using NetworkMonitoring.Application.Repository.BasicData;
using NetworkMonitoring.Application.Infrastracture.Service;
using NetworkMonitoring.Application.Repository.Service;
using NetworkMonitoring.Application.Infrastracture.Report;
using NetworkMonitoring.Application.Repository.Report;

var builder = WebApplication.CreateBuilder(args);

//CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = PersianDateExtensionMethods.GetPersianCulture();

#region DB
builder.Services.AddDbContext<NetworkMonitoringDbContext>(options => options.UseSqlServer(builder.Configuration["DefaultConnection"]));
#endregion

#region Application
builder.Services.AddScoped<IAccount, AccountRepository>();
builder.Services.AddScoped<IBasicData, BasicDataRepository>();
builder.Services.AddScoped<IService, ServiceRepository>();
builder.Services.AddScoped<IReport, ReportRepository>();
#endregion

#region Services
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddRazorPages().Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Login");
});
#endregion

#region For Authentication
builder.Services.AddAuthentication().AddCookie(options =>
{
    options.Cookie.HttpOnly = true;//Users Cant Change Cookie With Javscript
    options.SlidingExpiration = true;//dont regenerate cookie expiration time
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    options.Cookie.Name = "NetworkMonitoring";
});
#endregion

var app = builder.Build();
app.UseExceptionHandler("/Error");
app.UseHsts();
app.UseStatusCodePagesWithRedirects("~/404");
#region Use For Authentication
app.UseAuthentication();
app.UseAuthorization();
#endregion
app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMvc();

app.Run();
