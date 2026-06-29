using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikerXY.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloMotoConStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ambiente",
                table: "Motos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Motos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Motos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ambiente", "Descripcion", "Stock" },
                values: new object[] { "", "", 0 });

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ambiente", "Descripcion", "Stock" },
                values: new object[] { "", "", 0 });

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ambiente", "Descripcion", "Stock" },
                values: new object[] { "", "", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ambiente",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Motos");
        }
    }
}
