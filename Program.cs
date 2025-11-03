using Microsoft.EntityFrameworkCore;
using peliculasweb.Data; // <-- Asegúrate que el namespace coincida

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// LOG FATAL ERRORS TO FILE!
AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
{
    File.WriteAllText("fatal_error.log", eventArgs.ExceptionObject?.ToString() ?? "Unknown fatal error");
};

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();