using StudentApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// register the resource filter, now every request will be logged before and after the action executes
builder.Services.AddScoped<LogResourceFilter>();
// register the validation filter, now the student name will be validated before the action executes
builder.Services.AddScoped<ValidateStudentFilter>();
// register the exception filter, now all unhandled exceptions will be caught and logged
builder.Services.AddScoped<CustomExceptionFilter>();
// append message
builder.Services.AddScoped<AppendMessageFilter>();
// Custom authorization
builder.Services.AddScoped<CustomAuthorizationFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();