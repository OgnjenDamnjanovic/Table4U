﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWEProject.Models;

namespace Table4U.Migrations
{
    [DbContext(typeof(Table4UContext))]
    partial class Table4UContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SWEProject.Models.Dogadjaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LokalId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LokalId");

                    b.ToTable("Dogadjaji");
                });

            modelBuilder.Entity("SWEProject.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("mojLokalId")
                        .HasColumnType("int");

                    b.Property<string>("tipKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("mojLokalId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("SWEProject.Models.Lokal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("brOcena")
                        .HasColumnType("int");

                    b.Property<DateTime>("closeTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("latitude")
                        .HasColumnType("bigint");

                    b.Property<long>("longitude")
                        .HasColumnType("bigint");

                    b.Property<int>("maxKapacitet")
                        .HasColumnType("int");

                    b.Property<string>("nazivSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("openTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("trenutniKapacitet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lokali");
                });

            modelBuilder.Entity("SWEProject.Models.Recenzija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("LokalId")
                        .HasColumnType("int");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("LokalId");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("SWEProject.Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("LokalId")
                        .HasColumnType("int");

                    b.Property<int?>("StoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("LokalId");

                    b.HasIndex("StoId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("SWEProject.Models.Sto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LokalId")
                        .HasColumnType("int");

                    b.Property<bool>("Slobodan")
                        .HasColumnType("bit");

                    b.Property<int>("brojMesta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LokalId");

                    b.ToTable("Stolovi");
                });

            modelBuilder.Entity("SWEProject.Models.Dogadjaj", b =>
                {
                    b.HasOne("SWEProject.Models.Lokal", "Lokal")
                        .WithMany("listaDogadjaja")
                        .HasForeignKey("LokalId");
                });

            modelBuilder.Entity("SWEProject.Models.Korisnik", b =>
                {
                    b.HasOne("SWEProject.Models.Lokal", "mojLokal")
                        .WithMany()
                        .HasForeignKey("mojLokalId");
                });

            modelBuilder.Entity("SWEProject.Models.Recenzija", b =>
                {
                    b.HasOne("SWEProject.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWEProject.Models.Lokal", "Lokal")
                        .WithMany("listaRecenzija")
                        .HasForeignKey("LokalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SWEProject.Models.Rezervacija", b =>
                {
                    b.HasOne("SWEProject.Models.Korisnik", "Korisnik")
                        .WithMany("mojeRezervacije")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWEProject.Models.Lokal", "Lokal")
                        .WithMany("listaRezervacija")
                        .HasForeignKey("LokalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWEProject.Models.Sto", "Sto")
                        .WithMany()
                        .HasForeignKey("StoId");
                });

            modelBuilder.Entity("SWEProject.Models.Sto", b =>
                {
                    b.HasOne("SWEProject.Models.Lokal", "Lokal")
                        .WithMany("listaStolova")
                        .HasForeignKey("LokalId");
                });
#pragma warning restore 612, 618
        }
    }
}
