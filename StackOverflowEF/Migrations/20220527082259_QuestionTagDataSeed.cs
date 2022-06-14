using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class QuestionTagDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionTags",
                columns: new[] { "QuestionId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionTags",
                keyColumns: new[] { "QuestionId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "QuestionTags",
                keyColumns: new[] { "QuestionId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "QuestionTags",
                keyColumns: new[] { "QuestionId", "TagId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "QuestionTags",
                keyColumns: new[] { "QuestionId", "TagId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "QuestionTags",
                keyColumns: new[] { "QuestionId", "TagId" },
                keyValues: new object[] { 4, 4 });
        }
    }
}
