using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class AnswersPointsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Questions_QuestionId",
                table: "Points");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Points",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Points_AnswerId",
                table: "Points",
                column: "AnswerId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points",
                sql: "[QuestionId] IS NOT NULL OR [AnswerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Answers_AnswerId",
                table: "Points",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Questions_QuestionId",
                table: "Points",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Answers_AnswerId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Questions_QuestionId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_AnswerId",
                table: "Points");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Points_AnswerId_QuestionId_NotBothNull",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Questions_QuestionId",
                table: "Points",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
