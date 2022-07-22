using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefanini.ViaReport.DataStorage.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomField15703",
                table: "Issues");

            migrationBuilder.AlterColumn<bool>(
                name: "Incident",
                table: "Issues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Issues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Issues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IssueEpics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Progress = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quarter = table.Column<string>(type: "TEXT", nullable: true),
                    IssueId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueEpics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueEpics_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueImpediments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IssueId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueImpediments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueImpediments_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueEpics_IssueId",
                table: "IssueEpics",
                column: "IssueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueImpediments_IssueId",
                table: "IssueImpediments",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueEpics");

            migrationBuilder.DropTable(
                name: "IssueImpediments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Issues");

            migrationBuilder.AlterColumn<bool>(
                name: "Incident",
                table: "Issues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomField15703",
                table: "Issues",
                type: "TEXT",
                nullable: true);
        }
    }
}
