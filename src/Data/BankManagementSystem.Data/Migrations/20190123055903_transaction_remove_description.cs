using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class transaction_remove_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                nullable: true);
        }
    }
}
