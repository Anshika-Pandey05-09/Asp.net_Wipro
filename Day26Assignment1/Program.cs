using Day26Assignment1.Middleware;
using Day26Assignment1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Build the app
var app = builder.Build();

// Middleware: Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error.html");
    app.UseHsts();
}

// Middleware: Force HTTPS
app.UseHttpsRedirection();

// Middleware: Add basic Content Security Policy
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self';");
    await next();
});

// Custom Middleware for logging requests/responses
app.UseRequestResponseLogging();

// Serve static files from wwwroot
app.UseStaticFiles();

// Default route if nothing matches
app.MapGet("/", () => "Hello from MiddlewareApp (Minimal API)!");

app.Run();