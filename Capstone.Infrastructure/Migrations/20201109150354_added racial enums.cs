using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Infrastructure.Migrations
{
    public partial class addedracialenums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Commentable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subrace",
                table: "Commentable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Race",
                table: "Commentable");

            migrationBuilder.DropColumn(
                name: "Subrace",
                table: "Commentable");
        }
    }
}
