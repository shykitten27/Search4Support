using Microsoft.EntityFrameworkCore.Migrations;

namespace Search4Support.Migrations
{
    public partial class MapLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressUrl",
                table: "Providers");

            migrationBuilder.AddColumn<string>(
                name: "MapLink",
                table: "Providers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapLink",
                table: "Providers");

            migrationBuilder.AddColumn<string>(
                name: "AddressUrl",
                table: "Providers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
