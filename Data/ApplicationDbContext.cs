using Microsoft.EntityFrameworkCore;
using BikerXY.Models;

namespace BikerXY.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Este método se ejecuta al crear la base de datos para meter datos iniciales
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moto>().HasData(
                new Moto
                {
                    Id = 1,
                    Marca = "Yamaha",
                    Modelo = "R1",
                    Cilindrada = 998,
                    Precio = 17500.00m,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZZoQ8llcmttyfWYYJbC4VKwJuhSjNJgnvykkFha1Yz5FcRnVsH_ZvE8g&s=10",
                    Categoria = "Deportiva"
                },
                new Moto
                {
                    Id = 2,
                    Marca = "Honda",
                    Modelo = "Africa Twin",
                    Cilindrada = 1084,
                    Precio = 14800.00m,
                    ImagenUrl = "https://www.doble.co.uk/i/1295/oct2023-honda-africatwin-advsports-cover.webp?r=6161",
                    Categoria = "Adventure"
                },
                new Moto
                {
                    Id = 3,
                    Marca = "Kawasaki",
                    Modelo = "Z900",
                    Cilindrada = 948,
                    Precio = 9300.00m,
                    ImagenUrl = "https://motoblog.com/wp-content/uploads/2025/10/WhatsApp-Image-2025-10-29-at-14.20.43.jpeg",
                    Categoria = "Naked"
                }
            );
        }
    }
}