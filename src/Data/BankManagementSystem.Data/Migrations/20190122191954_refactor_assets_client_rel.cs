using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class refactor_assets_client_rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AspNetUsers_ClientId",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Assets",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_ClientId",
                table: "Assets",
                newName: "IX_Assets_VendorId");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Assets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OwnerId",
                table: "Assets",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AspNetUsers_OwnerId",
                table: "Assets",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AspNetUsers_VendorId",
                table: "Assets",
                column: "VendorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AspNetUsers_OwnerId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AspNetUsers_VendorId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_OwnerId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Assets",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_VendorId",
                table: "Assets",
                newName: "IX_Assets_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AspNetUsers_ClientId",
                table: "Assets",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
