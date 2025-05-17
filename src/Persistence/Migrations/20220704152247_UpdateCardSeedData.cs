using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    public partial class UpdateCardSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("91dc58ae-18f3-49ed-8784-e62348c9d6b1"));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "Cards",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UnicodeValue",
                table: "Cards",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7465), new TimeSpan(0, 0, 0, 0, 0)), 5f });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 0, 0, 0, 0)), 2f });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7462), new TimeSpan(0, 0, 0, 0, 0)), 1f });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7464), new TimeSpan(0, 0, 0, 0, 0)), 3f });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[] { new Guid("01960104-3034-4735-b7e9-9831f00d33e5"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7479), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "S", 3f });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue" },
                values: new object[] { new Guid("1f7ab1e7-b95f-4016-b93d-5aeaae7b0f08"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7484), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "☕" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[,]
                {
                    { new Guid("351e04c7-f70a-4f08-bec1-17282e7ceda8"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7466), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "20", 20f },
                    { new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7474), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "89", 89f },
                    { new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "21", 21f },
                    { new Guid("4d302d7d-8ce3-4b04-9b67-5d359d6b96c3"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7475), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "100", 100f },
                    { new Guid("589c0ebd-cebd-4efd-9440-d1a98e3bd744"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "40", 40f }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue" },
                values: new object[] { new Guid("59f79917-dc46-4d30-a112-851c14c4d780"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7512), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "?" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[,]
                {
                    { new Guid("670f5580-30c8-4c64-9930-d3132e14cfd9"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7480), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "L", 8f },
                    { new Guid("7bab12bd-53e0-4034-9f52-36b3a02c25ae"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7473), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "80", 80f },
                    { new Guid("7fc35e2b-4fbe-4f36-b1e2-2a92f05f2a05"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7478), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "XS", 2f },
                    { new Guid("80e1dce7-a389-4778-863b-a5ec23b5d62f"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7482), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "XL", 13f }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue" },
                values: new object[] { new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7458), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "0" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[,]
                {
                    { new Guid("b2e3dd14-a3be-4506-a9a2-160d3b4bf5dd"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7476), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "XXS", 1f },
                    { new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7465), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "8", 8f },
                    { new Guid("cc871e03-1cc9-461b-85a8-b71a022fad67"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7479), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "M", 5f },
                    { new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7466), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "13", 13f },
                    { new Guid("d64d6b00-b364-468c-b138-473df4a484cb"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7463), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "½", 0.5f },
                    { new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7468), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "34", 34f },
                    { new Guid("df9c7caa-46a1-485b-a9de-730137706624"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7470), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "55", 55f },
                    { new Guid("f8eba7c5-879e-4df6-b0a8-ea5f02d8da51"), new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(7483), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "XXL", 21f }
                });

            migrationBuilder.InsertData(
                table: "DeckCards",
                columns: new[] { "CardId", "DeckId" },
                values: new object[,]
                {
                    { new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") }
                });

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 15, 22, 47, 569, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "DeckCards",
                columns: new[] { "CardId", "DeckId" },
                values: new object[,]
                {
                    { new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("59f79917-dc46-4d30-a112-851c14c4d780"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") },
                    { new Guid("df9c7caa-46a1-485b-a9de-730137706624"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("01960104-3034-4735-b7e9-9831f00d33e5"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("1f7ab1e7-b95f-4016-b93d-5aeaae7b0f08"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("351e04c7-f70a-4f08-bec1-17282e7ceda8"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("4d302d7d-8ce3-4b04-9b67-5d359d6b96c3"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("589c0ebd-cebd-4efd-9440-d1a98e3bd744"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("670f5580-30c8-4c64-9930-d3132e14cfd9"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7bab12bd-53e0-4034-9f52-36b3a02c25ae"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7fc35e2b-4fbe-4f36-b1e2-2a92f05f2a05"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("80e1dce7-a389-4778-863b-a5ec23b5d62f"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b2e3dd14-a3be-4506-a9a2-160d3b4bf5dd"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cc871e03-1cc9-461b-85a8-b71a022fad67"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d64d6b00-b364-468c-b138-473df4a484cb"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("f8eba7c5-879e-4df6-b0a8-ea5f02d8da51"));

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("59f79917-dc46-4d30-a112-851c14c4d780"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "DeckCards",
                keyColumns: new[] { "CardId", "DeckId" },
                keyValues: new object[] { new Guid("df9c7caa-46a1-485b-a9de-730137706624"), new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9") });

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("59f79917-dc46-4d30-a112-851c14c4d780"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"));

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("df9c7caa-46a1-485b-a9de-730137706624"));

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "UnicodeValue",
                table: "Cards",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7552), new TimeSpan(0, 0, 0, 0, 0)), 5 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7549), new TimeSpan(0, 0, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7546), new TimeSpan(0, 0, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7551), new TimeSpan(0, 0, 0, 0, 0)), 3 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UnicodeValue", "Value" },
                values: new object[] { new Guid("91dc58ae-18f3-49ed-8784-e62348c9d6b1"), new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "8", 8 });

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2022, 7, 4, 7, 11, 37, 581, DateTimeKind.Unspecified).AddTicks(8198), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}