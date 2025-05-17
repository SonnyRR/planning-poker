using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    public partial class RenamedJunctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableUser_Tables_TablesId",
                table: "TableUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TableUser_Users_PlayersId",
                table: "TableUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableUser",
                table: "TableUser");

            migrationBuilder.RenameTable(
                name: "TableUser",
                newName: "PlayerTables");

            migrationBuilder.RenameIndex(
                name: "IX_TableUser_TablesId",
                table: "PlayerTables",
                newName: "IX_PlayerTables_TablesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTables",
                table: "PlayerTables",
                columns: new[] { "PlayersId", "TablesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTables_Tables_TablesId",
                table: "PlayerTables",
                column: "TablesId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTables_Users_PlayersId",
                table: "PlayerTables",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTables_Tables_TablesId",
                table: "PlayerTables");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTables_Users_PlayersId",
                table: "PlayerTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTables",
                table: "PlayerTables");

            migrationBuilder.RenameTable(
                name: "PlayerTables",
                newName: "TableUser");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTables_TablesId",
                table: "TableUser",
                newName: "IX_TableUser_TablesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableUser",
                table: "TableUser",
                columns: new[] { "PlayersId", "TablesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TableUser_Tables_TablesId",
                table: "TableUser",
                column: "TablesId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableUser_Users_PlayersId",
                table: "TableUser",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}