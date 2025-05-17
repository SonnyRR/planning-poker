using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    public partial class IntroduceCardDecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeckType",
                table: "Tables");

            migrationBuilder.AddColumn<Guid>(
                name: "DeckId",
                table: "Tables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnicodeValue = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => new { x.CardId, x.DeckId });
                    table.ForeignKey(
                        name: "FK_DeckCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckCards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[,]
                {
                    { new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "5", 5 },
                    { new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "2", 2 },
                    { new Guid("91dc58ae-18f3-49ed-8784-e62348c9d6b1"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5997), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "8", 8 },
                    { new Guid("92242626-dbf5-4888-8876-66cb9d088e02"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "1", 1 },
                    { new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5995), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Type" },
                values: new object[] { new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"), new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(6389), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Fibonacci" });

            migrationBuilder.InsertData(
                table: "DeckCards",
                columns: new[] { "CardId", "DeckId" },
                values: new object[] { new Guid("92242626-dbf5-4888-8876-66cb9d088e02"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_DeckId",
                table: "Tables",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UnicodeValue",
                table: "Cards",
                column: "UnicodeValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_DeckId",
                table: "DeckCards",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Decks_DeckId",
                table: "Tables",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Decks_DeckId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Tables_DeckId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Tables");

            migrationBuilder.AddColumn<string>(
                name: "DeckType",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}