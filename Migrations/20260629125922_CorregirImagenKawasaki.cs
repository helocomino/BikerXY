using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikerXY.Migrations
{
    /// <inheritdoc />
    public partial class CorregirImagenKawasaki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://images.unsplash.com/photo-1609630875171-b1321377ee65?q=80&w=600");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagenUrl",
                value: "https://images.unsplash.com/photo-1614162692292-7ac56d7f7f1e?q=80&w=600");
        }
    }
}
