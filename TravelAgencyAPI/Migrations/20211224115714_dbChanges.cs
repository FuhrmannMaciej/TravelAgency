using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyAPI.Migrations
{
    public partial class dbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelID",
                table: "Offers",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
