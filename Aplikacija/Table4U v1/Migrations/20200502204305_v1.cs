using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class v1 : Migration
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
                    Grad = table.Column<string>(nullable: true),
                    latitude = table.Column<decimal>(type: "[decimal](18, 15)", nullable: false),
                    longitude = table.Column<decimal>(type: "[decimal](18, 15)", nullable: false),
                    maxKapacitet = table.Column<int>(nullable: false),
                    trenutniKapacitet = table.Column<int>(nullable: false),
                    Ocena = table.Column<float>(nullable: false),
                    brOcena = table.Column<int>(nullable: false),
                    nazivSlike = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    opis = table.Column<string>(nullable: true),
                    slika1 = table.Column<string>(nullable: true),
                    slika2 = table.Column<string>(nullable: true),
                    slika3 = table.Column<string>(nullable: true),
                    slika4 = table.Column<string>(nullable: true),
                    slika5 = table.Column<string>(nullable: true)
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
                    LokalId = table.Column<int>(nullable: true),
                    oznaka = table.Column<string>(nullable: true),
                    gsX = table.Column<int>(nullable: false),
                    gsY = table.Column<int>(nullable: false),
                    gsHeight = table.Column<int>(nullable: false),
                    gsWidth = table.Column<int>(nullable: false)
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
                name: "Recenzije",
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
                    table.PrimaryKey("PK_Recenzije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzije_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzije_Lokali_LokalId",
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
                    VremeKreiranja = table.Column<DateTime>(nullable: false),
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
                name: "IX_Recenzije_KorisnikId",
                table: "Recenzije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_LokalId",
                table: "Recenzije",
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
                name: "Recenzije");

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
