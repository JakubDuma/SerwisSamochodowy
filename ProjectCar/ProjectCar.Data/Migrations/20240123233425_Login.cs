using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCar.Data.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Parts",
                newName: "InServiceDisposal");

            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Parts",
                newName: "Quantity");

            migrationBuilder.AddColumn<long>(
                name: "Nip",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "UserId",
                table: "Timetables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Margin",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Price",
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
                name: "UserId",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "Margin",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Parts",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "InServiceDisposal",
                table: "Parts",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
