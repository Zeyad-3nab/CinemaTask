using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActorsId",
                table: "actorMovies",
                newName: "actorId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "actorMovies",
                newName: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_actorMovies_actorId",
                table: "actorMovies",
                column: "actorId");

            migrationBuilder.AddForeignKey(
                name: "FK_actorMovies_actors_actorId",
                table: "actorMovies",
                column: "actorId",
                principalTable: "actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_actorMovies_movies_movieId",
                table: "actorMovies",
                column: "movieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actorMovies_actors_actorId",
                table: "actorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_actorMovies_movies_movieId",
                table: "actorMovies");

            migrationBuilder.DropIndex(
                name: "IX_actorMovies_actorId",
                table: "actorMovies");

            migrationBuilder.RenameColumn(
                name: "actorId",
                table: "actorMovies",
                newName: "ActorsId");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "actorMovies",
                newName: "MoviesId");
        }
    }
}
