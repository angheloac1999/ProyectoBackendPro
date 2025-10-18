using Microsoft.EntityFrameworkCore;
using peliculasweb.Data; // <- Asegúrate de que el namespace coincida con tu AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios MVC
builder.Services.AddControllersWithViews();

// Configura el AppDbContext con la cadena de conexión de SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();