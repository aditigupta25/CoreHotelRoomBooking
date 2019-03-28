using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreHotelRoomBookingAdminPortal.Migrations
{
    public partial class Hotel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HotelTypeName",
                table: "HotelTypes",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HotelTypeName",
                table: "HotelTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
