using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_MVC_IA_CAST.Migrations
{
    public partial class migra0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "podcastEpisodeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podcastEpisodeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "guestModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    podcastEpisodeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guestModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_guestModel_podcastEpisodeModel_podcastEpisodeModelId",
                        column: x => x.podcastEpisodeModelId,
                        principalTable: "podcastEpisodeModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hostModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    podcastEpisodeModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hostModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hostModel_podcastEpisodeModel_podcastEpisodeModelId",
                        column: x => x.podcastEpisodeModelId,
                        principalTable: "podcastEpisodeModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_guestModel_podcastEpisodeModelId",
                table: "guestModel",
                column: "podcastEpisodeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_hostModel_podcastEpisodeModelId",
                table: "hostModel",
                column: "podcastEpisodeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guestModel");

            migrationBuilder.DropTable(
                name: "hostModel");

            migrationBuilder.DropTable(
                name: "podcastEpisodeModel");
        }
    }
}
