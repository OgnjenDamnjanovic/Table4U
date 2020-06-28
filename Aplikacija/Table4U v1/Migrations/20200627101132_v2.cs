using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reports",
                table: "Korisnici",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reports",
                table: "Korisnici");
        }
    }
}
