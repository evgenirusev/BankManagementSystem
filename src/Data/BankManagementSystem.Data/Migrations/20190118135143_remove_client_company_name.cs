using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class remove_client_company_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
