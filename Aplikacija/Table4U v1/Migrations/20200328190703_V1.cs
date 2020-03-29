using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokali",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    openTime = table.Column<DateTime>(nullable: false),
                    closeTime = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    latitude = table.Column<long>(nullable: false),
                    longitude = table.Column<long>(nullable: false),
                    maxKapacitet = table.Column<int>(nullable: false),
                    trenutniKapacitet = table.Column<int>(nullable: false),
                    Ocena = table.Column<int>(nullable: false),
                    brOcena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogadjaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    LokalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogadjaji_Lokali_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipKorisnika = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    eMail = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    mojLokalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Lokali_mojLokalId",
                        column: x => x.mojLokalId,
                        principalTable: "Lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stolovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojMesta = table.Column<int>(nullable: false),
                    Slobodan = table.Column<bool>(nullable: false),
                    LokalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stolovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stolovi_Lokali_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(nullable: false),
                    Komentar = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    LokalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzija_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzija_Lokali_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    LokalId = table.Column<int>(nullable: false),
                    Vreme = table.Column<DateTime>(nullable: false),
                    StoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Lokali_LokalId",
                        column: x => x.LokalId,
                        principalTable: "Lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Stolovi_StoId",
                        column: x => x.StoId,
                        principalTable: "Stolovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaji_LokalId",
                table: "Dogadjaji",
                column: "LokalId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_mojLokalId",
                table: "Korisnici",
                column: "mojLokalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KorisnikId",
                table: "Recenzija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_LokalId",
                table: "Recenzija",
                column: "LokalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_LokalId",
                table: "Rezervacije",
                column: "LokalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_StoId",
                table: "Rezervacije",
                column: "StoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stolovi_LokalId",
                table: "Stolovi",
                column: "LokalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogadjaji");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Stolovi");

            migrationBuilder.DropTable(
                name: "Lokali");
        }
    }
}
