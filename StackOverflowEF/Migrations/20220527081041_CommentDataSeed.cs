using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class CommentDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnswerId", "Content", "QuestionId", "UserId" },
                values: new object[] { 1, 1, "Good", null, new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnswerId", "Content", "QuestionId", "UserId" },
                values: new object[] { 2, 2, "Wrong", null, new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnswerId", "Content", "QuestionId", "UserId" },
                values: new object[] { 3, null, "Nice", 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
