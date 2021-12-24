using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyAPI.Migrations
{
    public partial class hideProps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingStatuses_BookingStatusID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingStatusID",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStatusID",
                table: "Bookings",
                column: "BookingStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingStatuses_BookingStatusID",
                table: "Bookings",
                column: "BookingStatusID",
                principalTable: "BookingStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
