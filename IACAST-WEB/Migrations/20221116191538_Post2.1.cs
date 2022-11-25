using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IACAST_WEB.Migrations
{
    public partial class Post21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagenName",
                table: "Post2",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagenName",
                table: "Post2");
        }
    }
}
