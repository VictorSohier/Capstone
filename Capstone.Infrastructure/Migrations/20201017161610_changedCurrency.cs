using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Infrastructure.Migrations
{
    public partial class changedCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SilverPiece",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PlatinumPiece",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GoldPiece",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectrumPiece",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CopperPiece",
                table: "Commentable",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "SilverPiece",
                table: "Commentable",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PlatinumPiece",
                table: "Commentable",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "GoldPiece",
                table: "Commentable",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ElectrumPiece",
                table: "Commentable",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "CopperPiece",
                table: "Commentable",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
