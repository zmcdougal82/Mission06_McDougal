using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mission06_McDougal.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 🔹 Get the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"🔎 Using SQLite database at: {connectionString}");

// 🔹 Register SQLite database context
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(connectionString)
);

// 🔹 Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 🔹 Define default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}"
);

app.Run();