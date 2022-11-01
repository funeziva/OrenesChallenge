using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixUbication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UbicationHistories_Orders_OrderId",
                table: "UbicationHistories");

            migrationBuilder.DropColumn(
                name: "Ubication",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "UbicationHistories",
                newName: "VehicleId");

            migrationBuilder.AddColumn<string>(
                name: "Ubication",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UbicationHistories_Vehicles_VehicleId",
                table: "UbicationHistories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UbicationHistories_Vehicles_VehicleId",
                table: "UbicationHistories");

            migrationBuilder.DropColumn(
                name: "Ubication",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "UbicationHistories",
                newName: "OrderId");

            migrationBuilder.AddColumn<string>(
                name: "Ubication",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UbicationHistories_Orders_OrderId",
                table: "UbicationHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
