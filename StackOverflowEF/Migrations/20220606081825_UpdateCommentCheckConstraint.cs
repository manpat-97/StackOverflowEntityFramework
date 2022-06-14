using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class UpdateCommentCheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments",
                sql: "(([QuestionId] IS NULL OR [AnswerId] IS NULL) AND NOT ([QuestionId] IS NULL AND [AnswerId] IS NULL))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments",
                sql: "[QuestionId] IS NOT NULL OR [AnswerId] IS NOT NULL");
        }
    }
}
