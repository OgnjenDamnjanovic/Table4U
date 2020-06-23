using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brojPrijava",
                table: "Korisnici",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "hash",
                table: "Korisnici",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "validanNalog",
                table: "Korisnici",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brojPrijava",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "hash",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "validanNalog",
                table: "Korisnici");
        }
    }
}
