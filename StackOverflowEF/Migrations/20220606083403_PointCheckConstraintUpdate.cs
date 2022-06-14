using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class PointCheckConstraintUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points",
                sql: "([QuestionId] IS NULL OR [AnswerId] IS NULL) AND NOT ([QuestionId] IS NULL AND [AnswerId] IS NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points",
                sql: "[QuestionId] IS NOT NULL OR [AnswerId] IS NOT NULL");
        }
    }
}
