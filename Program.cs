using Eccomerce_Full_Stack.data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

// Retrieve placeholders from environment variables
string dbName = Environment.GetEnvironmentVariable("DBNAME");
string username = Environment.GetEnvironmentVariable("USERNAME");
string password = Environment.GetEnvironmentVariable("PASSWORD");

// Get the connection string template from appsettings.json
string connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");

// Replace placeholders with actual values
string connectionString = connectionStringTemplate
    .Replace("{DBNAME}", dbName)
    .Replace("{USERNAME}", username)
    .Replace("{PASSWORD}", password);

// Configure PostgreSQL DbContext with the constructed connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Configure auto compile
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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