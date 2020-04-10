﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Table4U.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nazivSlike",
                table: "Lokali",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nazivSlike",
                table: "Lokali");
        }
    }
}