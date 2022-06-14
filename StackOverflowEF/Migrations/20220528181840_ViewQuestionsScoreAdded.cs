using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class ViewQuestionsScoreAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"  CREATE VIEW View_QuestionsScore AS
  SELECT q.Id,q.Title,q.Content, SUM(p.Value) AS Score
  FROM Questions q
  JOIN Points p on p.QuestionId = q.Id
  GROUP BY q.Id, q.Title, q.Content
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW View_QuestionsScore");
        }
    }
}
