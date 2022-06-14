using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class CommentDataSeedModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnswerId", "Content", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 4, null, "Comment 4", 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") },
                    { 5, null, "Comment", 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") },
                    { 6, null, "Comment 6", 2, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") },
                    { 7, null, "Comment 7", 1, new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") },
                    { 8, 2, "Wrong 2", null, new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
