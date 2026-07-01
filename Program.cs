using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos PostgreSQL en la nube (Render)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BikerXY.Data.ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // 👈 Activa el servicio de sesiones
builder.Services.AddHttpContextAccessor(); // 👈 AGREGA ESTA LÍNEA AQUÍ

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseSession(); // 👈 Permite a la app usar sesiones
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// 🔹 TRUCO DE RENDER: Migración y Stock de prueba automático
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BikerXY.Data.ApplicationDbContext>();

    context.Database.Migrate();

    // ✨ TRUCO TEMPORAL DE STOCK: Si hay motos con stock 0, les ponemos 5 para probar
    var motosSinStock = context.Motos.Where(m => m.Stock == 0).ToList();
    if (motosSinStock.Any())
    {
        foreach (var moto in motosSinStock)
        {
            moto.Stock = 5; // Le asignamos 5 unidades a cada una
        }
        context.SaveChanges(); // Guardamos los cambios en la base de datos de Render
    }
}

app.Run();