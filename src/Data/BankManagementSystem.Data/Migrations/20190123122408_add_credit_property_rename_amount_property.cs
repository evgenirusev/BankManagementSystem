using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class add_credit_property_rename_amount_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Credits",
                newName: "FinancialResourceAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentPeriod",
                table: "Credits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentPeriod",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "FinancialResourceAmount",
                table: "Credits",
                newName: "Amount");
        }
    }
}
