using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IACAST_WEB.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Guest_TheGuestId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Hosts_TheHostId",
                table: "Episode");

            migrationBuilder.DropIndex(
                name: "IX_Episode_TheGuestId",
                table: "Episode");

            migrationBuilder.DropIndex(
                name: "IX_Episode_TheHostId",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "TheGuestId",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "TheHostId",
                table: "Episode");

            migrationBuilder.AddColumn<string>(
                name: "Anfitrion",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anfitrion",
                table: "Episode");

            migrationBuilder.AddColumn<int>(
                name: "TheGuestId",
                table: "Episode",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheHostId",
                table: "Episode",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episode_TheGuestId",
                table: "Episode",
                column: "TheGuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_TheHostId",
                table: "Episode",
                column: "TheHostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Guest_TheGuestId",
                table: "Episode",
                column: "TheGuestId",
                principalTable: "Guest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Hosts_TheHostId",
                table: "Episode",
                column: "TheHostId",
                principalTable: "Hosts",
                principalColumn: "Id");
        }
    }
}
