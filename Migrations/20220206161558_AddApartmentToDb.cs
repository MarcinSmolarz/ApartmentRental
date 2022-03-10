using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentRental.Migrations
{
    public partial class AddApartmentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numberOfRooms = table.Column<int>(type: "int", nullable: false),
                    numberOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    area = table.Column<int>(type: "int", nullable: false),
                    isKitchenSeparateRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arePetsAllowed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ownerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartment");

        }
    }
}
