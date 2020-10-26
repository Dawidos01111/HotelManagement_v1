using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Migrations
{
    public partial class UpdateRooms2Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingStatusId",
                table: "rooms2s",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomImage",
                table: "rooms2s",
                type: "nvarchar(550)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "rooms2s",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingStatusId",
                table: "rooms2s");

            migrationBuilder.DropColumn(
                name: "RoomImage",
                table: "rooms2s");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "rooms2s");
        }
    }
}
