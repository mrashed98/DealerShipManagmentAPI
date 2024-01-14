using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShip.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "SalesPersonID",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalesPersonID",
                table: "Transaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Transaction",
                type: "datetime2",
                nullable: true);
        }
    }
}
