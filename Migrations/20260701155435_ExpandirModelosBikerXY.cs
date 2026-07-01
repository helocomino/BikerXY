using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BikerXY.Migrations
{
    /// <inheritdoc />
    public partial class ExpandirModelosBikerXY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ambiente",
                table: "Motos",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Motos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Motos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Motos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Motos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EsDestacada",
                table: "Motos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GifUrl",
                table: "Motos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactoLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCliente = table.Column<string>(type: "text", nullable: false),
                    CorreoCliente = table.Column<string>(type: "text", nullable: false),
                    TelefonoCliente = table.Column<string>(type: "text", nullable: true),
                    Mensaje = table.Column<string>(type: "text", nullable: false),
                    TipoSolicitud = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MotoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoLeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VentaReservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    MotoId = table.Column<int>(type: "integer", nullable: false),
                    TipoTransaccion = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaReservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaReservas_Motos_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Motos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Anio", "Descripcion", "EsDestacada", "Estado", "GifUrl", "Stock" },
                values: new object[] { 2024, "Superbike de alto rendimiento para pista y calle.", true, "Nueva", null, 3 });

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Anio", "Descripcion", "EsDestacada", "Estado", "GifUrl", "Stock" },
                values: new object[] { 2023, "Maxitrail legendaria lista para cualquier tipo de terreno.", true, "Nueva", null, 2 });

            migrationBuilder.UpdateData(
                table: "Motos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Anio", "Descripcion", "EsDestacada", "Estado", "GifUrl", "Stock" },
                values: new object[] { 2024, "Estilo Sugomi puro con aceleración agresiva y ágil.", false, "Nueva", null, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_VentaReservas_MotoId",
                table: "VentaReservas",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactoLeads");

            migrationBuilder.DropTable(
                name: "VentaReservas");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "EsDestacada",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "GifUrl",
                table: "Motos");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Motos",
                newName: "Ambiente");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Motos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Motos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Motos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
