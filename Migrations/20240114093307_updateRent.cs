using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShip.Migrations
{
    /// <inheritdoc />
    public partial class updateRent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Transaction");
        }
    }
}
