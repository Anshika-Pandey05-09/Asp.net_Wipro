using Day29_ECommerce_assignment2;
using Day29_ECommerce_assignment2.Filters;
using Day29_ECommerce_assignment2.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<LoggingFilter>();
});

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<LoggingFilter>();
builder.Services.AddScoped<AuthenticationFilter>();
builder.Services.AddScoped<GlobalExceptionFilter>();
// Authservice


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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