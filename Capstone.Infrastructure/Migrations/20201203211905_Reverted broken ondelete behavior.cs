using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Infrastructure.Migrations
{
    public partial class Revertedbrokenondeletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Authors_Comment_AuthorId",
                table: "Commentable");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Commentable_ParentId",
                table: "Commentable");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Authors_AuthorId1",
                table: "Commentable");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId1",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Authors_Comment_AuthorId",
                table: "Commentable",
                column: "Comment_AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Commentable_ParentId",
                table: "Commentable",
                column: "ParentId",
                principalTable: "Commentable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Authors_AuthorId1",
                table: "Commentable",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Authors_Comment_AuthorId",
                table: "Commentable");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Commentable_ParentId",
                table: "Commentable");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentable_Authors_AuthorId1",
                table: "Commentable");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId1",
                table: "Commentable",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Authors_Comment_AuthorId",
                table: "Commentable",
                column: "Comment_AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Commentable_ParentId",
                table: "Commentable",
                column: "ParentId",
                principalTable: "Commentable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentable_Authors_AuthorId1",
                table: "Commentable",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
