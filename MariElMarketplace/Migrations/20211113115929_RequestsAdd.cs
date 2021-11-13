using Microsoft.EntityFrameworkCore.Migrations;

namespace MariElMarketplace.Migrations
{
    public partial class RequestsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Requests");
        }
    }
}
