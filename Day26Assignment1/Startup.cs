using Day26Assignment1.Middleware;

namespace Day26Assignment1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services if needed
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Custom error page
                app.UseExceptionHandler("/error.html");
                app.UseHsts();
            }

            // Enforce HTTPS
            app.UseHttpsRedirection();

            // Add basic Content Security Policy
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy",
                    "default-src 'self'; script-src 'self'; style-src 'self';");
                await next();
            });

            // Custom Middleware for logging
            app.UseRequestResponseLogging();

            // Serve static files from wwwroot
            app.UseStaticFiles();

            // Default response (if no static file matches)
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from MiddlewareApp!");
            });
        }
    }
}
