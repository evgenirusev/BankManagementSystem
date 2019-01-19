using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class add_credit_card_date_registered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "CreditCard",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "CreditCard");
        }
    }
}
