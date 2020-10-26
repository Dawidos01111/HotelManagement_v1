using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Migrations
{
    public partial class UpdateModelRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomImageUrl",
                table: "rooms");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "roomTypes",
                newName: "RoomTypeName");

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomPrice",
                table: "rooms",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "signInUserModels",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "signUpUserModels",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_BookingStatusId",
                table: "rooms",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomTypeId",
                table: "rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_bookingStatuses_BookingStatusId",
                table: "rooms",
                column: "BookingStatusId",
                principalTable: "bookingStatuses",
                principalColumn: "BookingStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_roomTypes_RoomTypeId",
                table: "rooms",
                column: "RoomTypeId",
                principalTable: "roomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_bookingStatuses_BookingStatusId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_roomTypes_RoomTypeId",
                table: "rooms");

            migrationBuilder.DropTable(
                name: "signInUserModels");

            migrationBuilder.DropTable(
                name: "signUpUserModels");

            migrationBuilder.DropIndex(
                name: "IX_rooms_BookingStatusId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_RoomTypeId",
                table: "rooms");

            migrationBuilder.RenameColumn(
                name: "RoomTypeName",
                table: "roomTypes",
                newName: "RoomType");

            migrationBuilder.AlterColumn<string>(
                name: "RoomPrice",
                table: "rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl",
                table: "rooms",
                type: "nvarchar(550)",
                nullable: false,
                defaultValue: "");
        }
    }
}
