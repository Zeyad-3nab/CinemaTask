using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actorMovies",
                table: "actorMovies");

            migrationBuilder.DropIndex(
                name: "IX_actorMovies_actorId",
                table: "actorMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actorMovies",
                table: "actorMovies",
                columns: new[] { "actorId", "movieId" });

            migrationBuilder.CreateIndex(
                name: "IX_actorMovies_movieId",
                table: "actorMovies",
                column: "movieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_actorMovies",
                table: "actorMovies");

            migrationBuilder.DropIndex(
                name: "IX_actorMovies_movieId",
                table: "actorMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actorMovies",
                table: "actorMovies",
                columns: new[] { "movieId", "actorId" });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actorMovies_actorId",
                table: "actorMovies",
                column: "actorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId");
        }
    }
}
