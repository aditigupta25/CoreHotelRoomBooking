using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreHotelRoomBookingAdminPortal.Migrations
{
    public partial class Hotel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HotelTypeId",
                table: "Hotels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomImage",
                table: "HotelRooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomImage",
                table: "HotelRooms");

            migrationBuilder.AlterColumn<string>(
                name: "HotelTypeId",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
