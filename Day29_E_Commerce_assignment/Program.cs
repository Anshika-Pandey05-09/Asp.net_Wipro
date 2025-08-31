using Day29_E_Commerce_assignment.Constraints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Register route constraints
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("validCategory", typeof(ValidCategoryConstraint));
    options.ConstraintMap.Add("priceRange", typeof(PriceRangeConstraint));
});

// Add simple cookie auth (to test role-based routing)
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", opt =>
    {
        opt.LoginPath = "/Account/Login";
    });

var app = builder.Build();

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

// Complex route: Product details
app.MapControllerRoute(
    name: "products",
    pattern: "Products/{category:validCategory}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

// Complex route: Product filter
app.MapControllerRoute(
    name: "productsFilter",
    pattern: "Products/Filter/{category:validCategory}/{priceRange:priceRange}",
    defaults: new { controller = "Products", action = "Filter" });

// User Orders route
app.MapControllerRoute(
    name: "usersOrders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Needed for integration tests
public partial class Program { }