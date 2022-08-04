using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefanini.ViaReport.DataStorage.Migrations
{
    public partial class Migration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quarter",
                table: "IssueEpics");

            migrationBuilder.AddColumn<long>(
                name: "QuarterId",
                table: "IssueEpics",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quarters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueEpics_QuarterId",
                table: "IssueEpics",
                column: "QuarterId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueEpics_Quarters_QuarterId",
                table: "IssueEpics",
                column: "QuarterId",
                principalTable: "Quarters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueEpics_Quarters_QuarterId",
                table: "IssueEpics");

            migrationBuilder.DropTable(
                name: "Quarters");

            migrationBuilder.DropIndex(
                name: "IX_IssueEpics_QuarterId",
                table: "IssueEpics");

            migrationBuilder.DropColumn(
                name: "QuarterId",
                table: "IssueEpics");

            migrationBuilder.AddColumn<string>(
                name: "Quarter",
                table: "IssueEpics",
                type: "TEXT",
                nullable: true);
        }
    }
}
