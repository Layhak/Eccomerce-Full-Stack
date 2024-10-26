using Eccomerce_Full_Stack.data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

// Replace placeholders with actual values
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!
    .Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost")
    .Replace("{DB_PORT}", Environment.GetEnvironmentVariable("DB_PORT") ?? "5432")
    .Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME") ?? "postgres")
    .Replace("{DB_USERNAME}", Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres")
    .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres");

// Configure Postgres DbContext with the constructed connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Configure auto compile
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure session state
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Useful for debugging during development
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session middleware
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();