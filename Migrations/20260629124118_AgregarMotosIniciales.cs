using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikerXY.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMotosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Motos",
                columns: new[] { "Id", "Categoria", "Cilindrada", "ImagenUrl", "Marca", "Modelo", "Precio" },
                values: new object[,]
                {
                    { 1, "Deportiva", 998, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?q=80&w=600", "Yamaha", "R1", 17500.00m },
                    { 2, "Adventure", 1084, "https://images.unsplash.com/photo-1599819811279-d5ad9cccf838?q=80&w=600", "Honda", "Africa Twin", 14800.00m },
                    { 3, "Naked", 948, "https://images.unsplash.com/photo-1614162692292-7ac56d7f7f1e?q=80&w=600", "Kawasaki", "Z900", 9300.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
