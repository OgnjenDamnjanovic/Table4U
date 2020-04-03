using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Lokali",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Lokali");
        }
    }
}
