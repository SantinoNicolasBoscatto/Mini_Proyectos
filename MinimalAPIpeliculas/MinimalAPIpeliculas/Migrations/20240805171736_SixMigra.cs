using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPIpeliculas.Migrations
{
    /// <inheritdoc />
    public partial class SixMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Actores_ActorId",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_ActorId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Peliculas");

            migrationBuilder.CreateTable(
                name: "ActoresPeliculas",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Orden = table.Column<int>(type: "INTEGER", nullable: false),
                    Personaje = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActoresPeliculas", x => new { x.PeliculaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActoresPeliculas_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActoresPeliculas_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActoresPeliculas_ActorId",
                table: "ActoresPeliculas",
                column: "ActorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActoresPeliculas");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Peliculas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_ActorId",
                table: "Peliculas",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Actores_ActorId",
                table: "Peliculas",
                column: "ActorId",
                principalTable: "Actores",
                principalColumn: "Id");
        }
    }
}
