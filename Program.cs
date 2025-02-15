using Microsoft.EntityFrameworkCore;
using Mission06_McDougal.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Register SQLite database context
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"))
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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();