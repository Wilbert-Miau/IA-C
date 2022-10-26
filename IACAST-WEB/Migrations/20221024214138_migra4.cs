using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IACAST_WEB.Migrations
{
    public partial class migra4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Invitado",
                table: "Episode",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invitado",
                table: "Episode");
        }
    }
}
