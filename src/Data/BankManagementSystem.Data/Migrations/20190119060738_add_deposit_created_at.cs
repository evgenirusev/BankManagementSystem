using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class add_deposit_created_at : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Deposits");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Deposits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Deposits");

            migrationBuilder.AddColumn<int>(
                name: "DateTime",
                table: "Deposits",
                nullable: false,
                defaultValue: 0);
        }
    }
}
