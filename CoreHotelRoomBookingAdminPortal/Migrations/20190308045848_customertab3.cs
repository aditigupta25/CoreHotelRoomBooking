using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreHotelRoomBookingAdminPortal.Migrations
{
    public partial class customertab3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Customers",
                newName: "Country");

            migrationBuilder.AddColumn<int>(
                name: "zip",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "zip",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customers",
                newName: "Gender");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
