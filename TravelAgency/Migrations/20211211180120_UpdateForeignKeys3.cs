using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Migrations
{
    public partial class UpdateForeignKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Transports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_CityID",
                table: "Transports",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TicketTypeID",
                table: "Transports",
                column: "TicketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingID",
                table: "Payments",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CityID",
                table: "Offers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_HotelID",
                table: "Offers",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TransportID",
                table: "Offers",
                column: "TransportID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_HotelID",
                table: "HotelServices",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_RoomTypeID",
                table: "HotelServices",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityID",
                table: "Hotels",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_CityID",
                table: "Hotels",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelServices_Hotels_HotelID",
                table: "HotelServices",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelServices_RoomTypes_RoomTypeID",
                table: "HotelServices",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cities_CityID",
                table: "Offers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers",
                column: "TransportID",
                principalTable: "Transports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Cities_CityID",
                table: "Transports",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TicketTypes_TicketTypeID",
                table: "Transports",
                column: "TicketTypeID",
                principalTable: "TicketTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_CityID",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelServices_Hotels_HotelID",
                table: "HotelServices");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelServices_RoomTypes_RoomTypeID",
                table: "HotelServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cities_CityID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Cities_CityID",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TicketTypes_TicketTypeID",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_CityID",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TicketTypeID",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BookingID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CityID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_HotelID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_TransportID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_HotelServices_HotelID",
                table: "HotelServices");

            migrationBuilder.DropIndex(
                name: "IX_HotelServices_RoomTypeID",
                table: "HotelServices");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CityID",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Transports");
        }
    }
}
