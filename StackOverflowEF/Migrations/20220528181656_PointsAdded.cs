using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class PointsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "QuestionId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), -1 },
                    { 2, 2, new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), 1 },
                    { 3, 3, new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), -1 },
                    { 4, 2, new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), 1 },
                    { 5, 3, new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), -1 },
                    { 7, 4, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), 1 },
                    { 8, 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), 1 },
                    { 9, 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), 1 },
                    { 10, 3, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_QuestionId",
                table: "Points",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_UserId",
                table: "Points",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
