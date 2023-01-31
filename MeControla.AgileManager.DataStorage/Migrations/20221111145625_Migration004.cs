using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_prj_id",
                schema: "agile_manager",
                table: "am_preference_status");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PreferenceClasseOfServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<uint>(type: "INTEGER", nullable: false),
                    ClasseOfServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceClasseOfServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferenceClasseOfServices_am_classe_of_service_ClasseOfServiceId",
                        column: x => x.ClasseOfServiceId,
                        principalSchema: "agile_manager",
                        principalTable: "am_classe_of_service",
                        principalColumn: "cof_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceClasseOfServices_am_project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_prj_id",
                schema: "agile_manager",
                table: "am_preference_status",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_issue_type_ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceClasseOfServices_ClasseOfServiceId",
                table: "PreferenceClasseOfServices",
                column: "ClasseOfServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceClasseOfServices_ProjectId",
                table: "PreferenceClasseOfServices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_am_preference_issue_type_am_project_ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "ProjectId1",
                principalSchema: "agile_manager",
                principalTable: "am_project",
                principalColumn: "prj_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_am_preference_issue_type_am_project_ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.DropTable(
                name: "PreferenceClasseOfServices");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_prj_id",
                schema: "agile_manager",
                table: "am_preference_status");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_issue_type_ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_prj_id",
                schema: "agile_manager",
                table: "am_preference_status",
                column: "prj_id",
                unique: true);
        }
    }
}
