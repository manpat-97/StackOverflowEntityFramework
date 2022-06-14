using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class CommentAddConstraintNotBothNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments",
                sql: "[QuestionId] IS NOT NULL OR [AnswerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Comments_AnswerId_QuestionId_NotBothNull",
                table: "Comments");
        }
    }
}
