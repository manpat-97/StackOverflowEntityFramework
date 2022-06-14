using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowEF.Migrations
{
    public partial class QuestionDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "How to add indexes by using Fluent API?", "Entity Framework", new Guid("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9") },
                    { 2, "How to configure services in ASP.NET Core?", "Asp .Net Core", new Guid("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98") },
                    { 3, "How to add Rotativa.aspnetcore configuration in Program.cs instead of RotativaConfiguration.Setup(env); that was in Startup.cs in .NET 5 and below?", "Asp .Net Core MVC", new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") },
                    { 4, "What is the difference between a DateTime and a DateTimeOffset and when should one be used?", "DateTime vs DateTimeOffset", new Guid("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
