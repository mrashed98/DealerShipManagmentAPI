using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShip.Migrations
{
	public partial class updateVehicle : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Drop existing columns
			migrationBuilder.DropColumn(
				name: "VehicleMake",
				table: "Vehicles");

			migrationBuilder.DropColumn(
				name: "VehicleModel",
				table: "Vehicles");

			// Add new columns as nullable
			migrationBuilder.AddColumn<int>(
				name: "VehicleMakeID",
				table: "Vehicles",
				type: "int",
				nullable: true); // Set as nullable

			migrationBuilder.AddColumn<int>(
				name: "VehicleModelID",
				table: "Vehicles",
				type: "int",
				nullable: true); // Set as nullable

			// Create indexes for the new columns
			migrationBuilder.CreateIndex(
				name: "IX_Vehicles_VehicleMakeID",
				table: "Vehicles",
				column: "VehicleMakeID");

			migrationBuilder.CreateIndex(
				name: "IX_Vehicles_VehicleModelID",
				table: "Vehicles",
				column: "VehicleModelID");

			// Add foreign key constraints (without cascade delete)
			migrationBuilder.AddForeignKey(
				name: "FK_Vehicles_Makes_VehicleMakeID",
				table: "Vehicles",
				column: "VehicleMakeID",
				principalTable: "Makes",
				principalColumn: "MakeID",
				onDelete: ReferentialAction.Restrict); // Use Restrict instead of Cascade

			migrationBuilder.AddForeignKey(
				name: "FK_Vehicles_Models_VehicleModelID",
				table: "Vehicles",
				column: "VehicleModelID",
				principalTable: "Models",
				principalColumn: "ModelID",
				onDelete: ReferentialAction.Restrict); // Use Restrict instead of Cascade
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			// Remove foreign keys
			migrationBuilder.DropForeignKey(
				name: "FK_Vehicles_Makes_VehicleMakeID",
				table: "Vehicles");

			migrationBuilder.DropForeignKey(
				name: "FK_Vehicles_Models_VehicleModelID",
				table: "Vehicles");

			// Remove indexes
			migrationBuilder.DropIndex(
				name: "IX_Vehicles_VehicleMakeID",
				table: "Vehicles");

			migrationBuilder.DropIndex(
				name: "IX_Vehicles_VehicleModelID",
				table: "Vehicles");

			// Remove new columns
			migrationBuilder.DropColumn(
				name: "VehicleMakeID",
				table: "Vehicles");

			migrationBuilder.DropColumn(
				name: "VehicleModelID",
				table: "Vehicles");

			// Add back the old columns
			migrationBuilder.AddColumn<string>(
				name: "VehicleMake",
				table: "Vehicles",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "VehicleModel",
				table: "Vehicles",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}
	}
}
