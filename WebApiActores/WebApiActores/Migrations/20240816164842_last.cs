using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiActores.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
