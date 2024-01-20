using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCar.Data.Migrations
{
    public partial class DataTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Parts",
                newName: "WarehouseAvailability");

            migrationBuilder.AddColumn<long>(
                name: "Nip",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarBrand",
                table: "Timetables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Timetables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Timetables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceAvailability",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nip",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarBrand",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "ServiceAvailability",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "WarehouseAvailability",
                table: "Parts",
                newName: "Availability");
        }
    }
}
