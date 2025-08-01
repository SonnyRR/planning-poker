using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PlanningPoker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IntroduceRoundsAndVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinalEstimation = table.Column<float>(type: "real", nullable: true),
                    StartedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estimation = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Users_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("01960104-3034-4735-b7e9-9831f00d33e5"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9248), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9187), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("1f7ab1e7-b95f-4016-b93d-5aeaae7b0f08"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9252), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("351e04c7-f70a-4f08-bec1-17282e7ceda8"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9238), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("4d302d7d-8ce3-4b04-9b67-5d359d6b96c3"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9245), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("589c0ebd-cebd-4efd-9440-d1a98e3bd744"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("59f79917-dc46-4d30-a112-851c14c4d780"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9253), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("670f5580-30c8-4c64-9930-d3132e14cfd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7bab12bd-53e0-4034-9f52-36b3a02c25ae"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7fc35e2b-4fbe-4f36-b1e2-2a92f05f2a05"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("80e1dce7-a389-4778-863b-a5ec23b5d62f"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9250), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b2e3dd14-a3be-4506-a9a2-160d3b4bf5dd"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9188), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cc871e03-1cc9-461b-85a8-b71a022fad67"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9249), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9186), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d64d6b00-b364-468c-b138-473df4a484cb"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9240), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("df9c7caa-46a1-485b-a9de-730137706624"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9241), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("f8eba7c5-879e-4df6-b0a8-ea5f02d8da51"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 677, DateTimeKind.Unspecified).AddTicks(9251), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 2, 11, 14, 10, 55, 678, DateTimeKind.Unspecified).AddTicks(1340), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_TableId",
                table: "Rounds",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PlayerId",
                table: "Votes",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_RoundId",
                table: "Votes",
                column: "RoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("01960104-3034-4735-b7e9-9831f00d33e5"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("12278530-7958-436a-a5a4-cf44daaaf95e"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("1f7ab1e7-b95f-4016-b93d-5aeaae7b0f08"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3422), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("351e04c7-f70a-4f08-bec1-17282e7ceda8"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("3def24db-bf68-490b-81c5-c52220e9d7ea"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("417d0c96-00c3-4cdb-b39c-2da688c80b87"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("4d302d7d-8ce3-4b04-9b67-5d359d6b96c3"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3416), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("589c0ebd-cebd-4efd-9440-d1a98e3bd744"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("59f79917-dc46-4d30-a112-851c14c4d780"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3423), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("670f5580-30c8-4c64-9930-d3132e14cfd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7bab12bd-53e0-4034-9f52-36b3a02c25ae"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3414), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("7fc35e2b-4fbe-4f36-b1e2-2a92f05f2a05"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("80e1dce7-a389-4778-863b-a5ec23b5d62f"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("911bdb42-7f5f-4431-9d11-95d63672edd9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3407), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("92242626-dbf5-4888-8876-66cb9d088e02"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3405), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("a0dc6082-0daf-45d1-989b-ac0dcbac10f5"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b2e3dd14-a3be-4506-a9a2-160d3b4bf5dd"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("b4c84e42-d1cc-40a6-8e6b-7028016cb8f6"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3409), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cc871e03-1cc9-461b-85a8-b71a022fad67"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d1e36f3e-1c12-417f-b60c-4e1fb1f62795"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3410), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d39ad4fa-3273-47ef-b46c-01ac37588c15"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("d64d6b00-b364-468c-b138-473df4a484cb"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("de6e7f04-3b9e-4913-a5a0-1bf16ec0bf0b"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3412), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("df9c7caa-46a1-485b-a9de-730137706624"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3413), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("f8eba7c5-879e-4df6-b0a8-ea5f02d8da51"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(3421), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: new Guid("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2024, 1, 27, 13, 28, 34, 47, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
