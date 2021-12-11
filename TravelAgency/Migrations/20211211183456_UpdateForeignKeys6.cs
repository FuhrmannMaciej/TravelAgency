using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Migrations
{
    public partial class UpdateForeignKeys6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "TransportID",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers",
                column: "TransportID",
                principalTable: "Transports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "TransportID",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Transports_TransportID",
                table: "Offers",
                column: "TransportID",
                principalTable: "Transports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
