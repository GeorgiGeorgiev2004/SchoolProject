using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealership.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Specialisation = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsNewRecruit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.MechanicId);
                });

            migrationBuilder.CreateTable(
                name: "Rentors",
                columns: table => new
                {
                    RentorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentors", x => x.RentorId);
                });

            migrationBuilder.CreateTable(
                name: "SalesMen",
                columns: table => new
                {
                    SalesManId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMen", x => x.SalesManId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorsePower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Rentors_RentorId",
                        column: x => x.RentorId,
                        principalTable: "Rentors",
                        principalColumn: "RentorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesMenVehicles",
                columns: table => new
                {
                    SalesManId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMenVehicles", x => new { x.VehicleId, x.SalesManId });
                    table.ForeignKey(
                        name: "FK_SalesMenVehicles_SalesMen_SalesManId",
                        column: x => x.SalesManId,
                        principalTable: "SalesMen",
                        principalColumn: "SalesManId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesMenVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesMechanics",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesMechanics", x => new { x.VehicleId, x.MechanicId });
                    table.ForeignKey(
                        name: "FK_VehiclesMechanics_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "MechanicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclesMechanics_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesMenVehicles_SalesManId",
                table: "SalesMenVehicles",
                column: "SalesManId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RentorId",
                table: "Vehicles",
                column: "RentorId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesMechanics_MechanicId",
                table: "VehiclesMechanics",
                column: "MechanicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesMenVehicles");

            migrationBuilder.DropTable(
                name: "VehiclesMechanics");

            migrationBuilder.DropTable(
                name: "SalesMen");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Rentors");
        }
    }
}
