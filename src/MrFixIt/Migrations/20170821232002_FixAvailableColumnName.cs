using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrFixIt.Migrations
{
    public partial class FixAvailableColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliable",
                table: "Workers");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Workers",
                nullable: true,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Workers");

            migrationBuilder.AddColumn<bool>(
                name: "Avaliable",
                table: "Workers",
                nullable: false,
                defaultValue: false);
        }
    }
}
