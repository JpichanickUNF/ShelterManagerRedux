var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["Connnectionstrings:MyConnection"];


// Load config from Azure App Configuration
//builder.Configuration.AddAzureAppConfiguration(connectionString);

builder.Services.AddRazorPages();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
