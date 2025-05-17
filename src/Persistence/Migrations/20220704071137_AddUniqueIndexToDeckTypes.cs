using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    public partial class AddUniqueIndexToDeckTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Decks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("91dc58ae-18f3-49ed-8784-e62348c9d6b1"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7546), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Decks_Type",
                table: "Decks",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Decks_Type",
                table: "Decks");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Decks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5996), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("91dc58ae-18f3-49ed-8784-e62348c9d6b1"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5997), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(5995), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 1, 14, 43, 8, 854, DateTimeKind.Unspecified).AddTicks(6389), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}