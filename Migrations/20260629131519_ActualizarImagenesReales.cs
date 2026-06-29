using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikerXY.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarImagenesReales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagenUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZZoQ8llcmttyfWYYJbC4VKwJuhSjNJgnvykkFha1Yz5FcRnVsH_ZvE8g&s=10");

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagenUrl",
                value: "https://www.doble.co.uk/i/1295/oct2023-honda-africatwin-advsports-cover.webp?r=6161");

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://motoblog.com/wp-content/uploads/2025/10/WhatsApp-Image-2025-10-29-at-14.20.43.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagenUrl",
                value: "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?q=80&w=600");

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagenUrl",
                value: "https://images.unsplash.com/photo-1599819811279-d5ad9cccf838?q=80&w=600");

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://images.unsplash.com/photo-1609630875171-b1321377ee65?q=80&w=600");
        }
    }
}
