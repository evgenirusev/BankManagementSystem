using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class add_asset_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Assets",
                newName: "MonetaryValue");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "MonetaryValue",
                table: "Assets",
                newName: "Amount");
        }
    }
}
