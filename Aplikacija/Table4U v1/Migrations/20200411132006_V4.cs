using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Ocena",
                table: "Lokali",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ocena",
                table: "Lokali",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
