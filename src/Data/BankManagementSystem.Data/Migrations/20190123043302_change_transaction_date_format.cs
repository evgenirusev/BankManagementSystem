using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class change_transaction_date_format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Transactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "DateTime",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
