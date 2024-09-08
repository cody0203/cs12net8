#region Configure the web server host and services.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

#endregion

#region Configure the HTTP pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
else

app.UseHttpsRedirection();
app.UseDefaultFiles(); // index.html, default.html, and so on.
app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/hello", () => $"Environemnt is {app.Environment.EnvironmentName}");
#endregion

app.Run();
WriteLine("This executes after the web server has stopped!");
