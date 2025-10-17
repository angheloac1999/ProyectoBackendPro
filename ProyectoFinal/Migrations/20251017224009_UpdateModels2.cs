using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Directores_DirectorId",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Generos_GeneroId",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_DirectorId",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_IdDirector",
                table: "Peliculas",
                column: "IdDirector");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_IdGenero",
                table: "Peliculas",
                column: "IdGenero");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Directores_IdDirector",
                table: "Peliculas",
                column: "IdDirector",
                principalTable: "Directores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Generos_IdGenero",
                table: "Peliculas",
                column: "IdGenero",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Directores_IdDirector",
                table: "Peliculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Peliculas_Generos_IdGenero",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_IdDirector",
                table: "Peliculas");

            migrationBuilder.DropIndex(
                name: "IX_Peliculas_IdGenero",
                table: "Peliculas");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_DirectorId",
                table: "Peliculas",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Directores_DirectorId",
                table: "Peliculas",
                column: "DirectorId",
                principalTable: "Directores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peliculas_Generos_GeneroId",
                table: "Peliculas",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
