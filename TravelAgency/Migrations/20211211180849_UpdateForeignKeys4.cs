using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Migrations
{
    public partial class UpdateForeignKeys4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cities_CityID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CityID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Offers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CityID",
                table: "Offers",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cities_CityID",
                table: "Offers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
