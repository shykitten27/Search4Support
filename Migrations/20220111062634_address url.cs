using Microsoft.EntityFrameworkCore.Migrations;

namespace Search4Support.Migrations
{
    public partial class addressurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressUrl",
                table: "Providers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressUrl",
                table: "Providers");
        }
    }
}
