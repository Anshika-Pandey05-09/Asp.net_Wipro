var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add session services
builder.Services.AddDistributedMemoryCache();//required for sessions management
builder.Services.AddSession( options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);//You can set Time   
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Above session configuration will retain user session data for 10 minutes 
// post inactivity it will be discarded

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

//Step 2
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
