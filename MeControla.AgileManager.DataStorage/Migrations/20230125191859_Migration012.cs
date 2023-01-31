using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    /// <inheritdoc />
    public partial class Migration012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeployId",
                schema: "agile_manager",
                table: "am_issue",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "am_deploy",
                schema: "agile_manager",
                columns: table => new
                {
                    dplid = table.Column<long>(name: "dpl_id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dpluuid = table.Column<Guid>(name: "dpl_uuid", type: "TEXT", maxLength: 36, nullable: false),
                    dplservices = table.Column<string>(name: "dpl_services", type: "TEXT", maxLength: 150, nullable: false),
                    dpldeployedin = table.Column<DateTime>(name: "dpl_deployed_in", type: "TEXT", nullable: true),
                    IssueId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_deploy", x => x.dplid);
                    table.ForeignKey(
                        name: "FK_am_deploy_am_issue_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_deploy_IssueId",
                schema: "agile_manager",
                table: "am_deploy",
                column: "IssueId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "am_deploy",
                schema: "agile_manager");

            migrationBuilder.DropColumn(
                name: "DeployId",
                schema: "agile_manager",
                table: "am_issue");
        }
    }
}
