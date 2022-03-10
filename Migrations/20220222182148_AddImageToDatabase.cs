using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentRental.Migrations
{
    public partial class AddImageToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "Apartment");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Apartment",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Apartment");

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "Apartment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
