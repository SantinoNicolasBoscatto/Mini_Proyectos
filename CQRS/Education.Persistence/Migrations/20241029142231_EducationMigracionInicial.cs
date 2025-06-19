using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("39f850fc-7974-4194-8712-6de0a44a140f"), "Curso de Testing", new DateTime(2024, 10, 29, 11, 22, 31, 392, DateTimeKind.Local).AddTicks(2717), new DateTime(2024, 10, 30, 11, 22, 31, 392, DateTimeKind.Local).AddTicks(2729), 33m, "Testing Master" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("e64500bd-5aa4-4a2e-bb67-3cdee1d9cb63"), "Curso de Java", new DateTime(2024, 10, 29, 11, 22, 31, 392, DateTimeKind.Local).AddTicks(2736), new DateTime(2024, 10, 30, 11, 22, 31, 392, DateTimeKind.Local).AddTicks(2737), 60m, "Java Master" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
