using Microsoft.EntityFrameworkCore;
using BikerXY.Models;

namespace BikerXY.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // 📊 TABLAS MAPEADAS EN LA BASE DE DATOS
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContactoLead> ContactoLeads { get; set; } // 🆕 Tabla para solicitudes y mensajes
        public DbSet<VentaReserva> VentaReservas { get; set; } // 🆕 Tabla para historial de transacciones

        // Este método mete los datos iniciales actualizados a la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moto>().HasData(
                new Moto
                {
                    Id = 1,
                    Marca = "Yamaha",
                    Modelo = "R1",
                    Anio = 2024, // 🆕 Propiedad requerida agregada
                    Cilindrada = 998,
                    Precio = 17500.00m,
                    Estado = "Nueva", // 🆕 Propiedad requerida agregada
                    Stock = 3,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZZoQ8llcmttyfWYYJbC4VKwJuhSjNJgnvykkFha1Yz5FcRnVsH_ZvE8g&s=10",
                    Categoria = "Deportiva",
                    Descripcion = "Superbike de alto rendimiento para pista y calle.",
                    EsDestacada = true // 🆕 Habilitada para el carrusel superior
                },
                new Moto
                {
                    Id = 2,
                    Marca = "Honda",
                    Modelo = "Africa Twin",
                    Anio = 2023, // 🆕 Propiedad requerida agregada
                    Cilindrada = 1084,
                    Precio = 14800.00m,
                    Estado = "Nueva", // 🆕 Propiedad requerida agregada
                    Stock = 2,
                    ImagenUrl = "https://www.doble.co.uk/i/1295/oct2023-honda-africatwin-advsports-cover.webp?r=6161",
                    Categoria = "Adventure",
                    Descripcion = "Maxitrail legendaria lista para cualquier tipo de terreno.",
                    EsDestacada = true // 🆕 Habilitada para el carrusel superior
                },
                new Moto
                {
                    Id = 3,
                    Marca = "Kawasaki",
                    Modelo = "Z900",
                    Anio = 2024, // 🆕 Propiedad requerida agregada
                    Cilindrada = 948,
                    Precio = 9300.00m,
                    Estado = "Nueva", // 🆕 Propiedad requerida agregada
                    Stock = 5,
                    ImagenUrl = "https://motoblog.com/wp-content/uploads/2025/10/WhatsApp-Image-2025-10-29-at-14.20.43.jpeg",
                    Categoria = "Naked",
                    Descripcion = "Estilo Sugomi puro con aceleración agresiva y ágil.",
                    EsDestacada = false
                }
            );
        }
    }
}