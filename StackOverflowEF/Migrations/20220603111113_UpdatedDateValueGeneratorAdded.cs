using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class UpdatedDateValueGeneratorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
               (@"CREATE TRIGGER [dbo].[Question_UPDATE] ON [dbo].[Questions]
                   AFTER UPDATE
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   IF((SELECT TRIGGER_NESTLEVEL())>1)RETURN;
                   DECLARE @Id INT
                   SELECT @Id = INSERTED.Id
                   FROM INSERTED
                   UPDATE dbo.Questions
                   SET UpdatedDate = GETUTCDATE()
                   WHERE Id = @Id
                   END"
               );
            migrationBuilder.Sql
               (@"CREATE TRIGGER [dbo].[Answer_UPDATE] ON [dbo].[Answers]
                   AFTER UPDATE
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   IF((SELECT TRIGGER_NESTLEVEL())>1)RETURN;
                   DECLARE @Id INT
                   SELECT @Id = INSERTED.Id
                   FROM INSERTED
                   UPDATE dbo.Answers
                   SET UpdatedDate = GETUTCDATE()
                   WHERE Id = @Id
                   END"
               );
            migrationBuilder.Sql
               (@"CREATE TRIGGER [dbo].[Comment_UPDATE] ON [dbo].[Comments]
                   AFTER UPDATE
                   AS
                   BEGIN
                   SET NOCOUNT ON;
                   IF((SELECT TRIGGER_NESTLEVEL())>1)RETURN;
                   DECLARE @Id INT
                   SELECT @Id = INSERTED.Id
                   FROM INSERTED
                   UPDATE dbo.Comments
                   SET UpdatedDate = GETUTCDATE()
                   WHERE Id = @Id
                   END"
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER [dbo].[Question_UPDATE]");
            migrationBuilder.Sql(@"DROP TRIGGER [dbo].[Answer_UPDATE]");
            migrationBuilder.Sql(@"DROP TRIGGER [dbo].[Comment_UPDATE]");
        }
    }
}
