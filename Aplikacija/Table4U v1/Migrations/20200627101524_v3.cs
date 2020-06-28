using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reports",
                table: "Korisnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reports",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
