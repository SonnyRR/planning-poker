using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    public partial class IntroducedTableOwnerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Tables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tables_OwnerId",
                table: "Tables",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Users_OwnerId",
                table: "Tables",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Users_OwnerId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_OwnerId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tables");
        }
    }
}
