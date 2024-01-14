using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShip.Migrations
{
    /// <inheritdoc />
    public partial class vehicleStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleStatus",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleStatusID",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleStatuses",
                columns: table => new
                {
                    VehicleStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStatuses", x => x.VehicleStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleStatusID",
                table: "Vehicles",
                column: "VehicleStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleStatuses_VehicleStatusID",
                table: "Vehicles",
                column: "VehicleStatusID",
                principalTable: "VehicleStatuses",
                principalColumn: "VehicleStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleStatuses_VehicleStatusID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleStatusID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleStatusID",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "VehicleStatus",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
