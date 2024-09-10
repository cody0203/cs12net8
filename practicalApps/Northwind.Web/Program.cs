using Northwind.EntityModels;

#region Configure the web server host and services.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddNorthwindContext();

var app = builder.Build();

#endregion

#region Configure the HTTP pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else

// Implementing an anonnymous inline delegaste as middleware
// to intercept HTTP requests and responses.

app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }

    if (context.Request.Path == "/bonjour")
    {
        // In The acse of a match on URL path, this becomes a terminating
        // delegate that returns so does not call the next delegate.

        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    // We could modify the request before calling the next delegate.
    await next();
});

app.UseHttpsRedirection();
app.UseDefaultFiles(); // index.html, default.html, and so on.
app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/hello", () => $"Environemnt is {app.Environment.EnvironmentName}");
#endregion

app.Run();
WriteLine("This executes after the web server has stopped!");
