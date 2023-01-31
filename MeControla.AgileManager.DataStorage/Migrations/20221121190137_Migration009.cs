using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferenceClasseOfServices");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_category_stct_id",
                schema: "agile_manager",
                table: "am_preference_status_category");

            migrationBuilder.AddColumn<long>(
                name: "StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "am_preference_class_of_service",
                schema: "agile_manager",
                columns: table => new
                {
                    pcos_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pcos_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    pcos_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    pcos_type = table.Column<uint>(type: "INTEGER", nullable: false),
                    cof_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_preference_class_of_service", x => x.pcos_id);
                    table.ForeignKey(
                        name: "FK_am_preference_class_of_service_am_class_of_service_cof_id",
                        column: x => x.cof_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_class_of_service",
                        principalColumn: "cof_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_preference_class_of_service_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_category_StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "StatusCategoryId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_category_stct_id",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "stct_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_issue_type_IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "IssueTypeId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_custom_field_CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "CustomFieldId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_class_of_service_cof_id",
                schema: "agile_manager",
                table: "am_preference_class_of_service",
                column: "cof_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_class_of_service_prj_id",
                schema: "agile_manager",
                table: "am_preference_class_of_service",
                column: "prj_id");

            migrationBuilder.AddForeignKey(
                name: "FK_am_preference_custom_field_am_custom_field_CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "CustomFieldId1",
                principalSchema: "agile_manager",
                principalTable: "am_custom_field",
                principalColumn: "cfd_id");

            migrationBuilder.AddForeignKey(
                name: "FK_am_preference_issue_type_am_issue_type_IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "IssueTypeId1",
                principalSchema: "agile_manager",
                principalTable: "am_issue_type",
                principalColumn: "istp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_am_preference_status_category_am_status_category_StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "StatusCategoryId1",
                principalSchema: "agile_manager",
                principalTable: "am_status_category",
                principalColumn: "stct_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_am_preference_custom_field_am_custom_field_CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field");

            migrationBuilder.DropForeignKey(
                name: "FK_am_preference_issue_type_am_issue_type_IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.DropForeignKey(
                name: "FK_am_preference_status_category_am_status_category_StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category");

            migrationBuilder.DropTable(
                name: "am_preference_class_of_service",
                schema: "agile_manager");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_category_StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_category_stct_id",
                schema: "agile_manager",
                table: "am_preference_status_category");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_issue_type_IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.DropIndex(
                name: "IX_am_preference_custom_field_CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field");

            migrationBuilder.DropColumn(
                name: "StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category");

            migrationBuilder.DropColumn(
                name: "IssueTypeId1",
                schema: "agile_manager",
                table: "am_preference_issue_type");

            migrationBuilder.DropColumn(
                name: "CustomFieldId1",
                schema: "agile_manager",
                table: "am_preference_custom_field");

            migrationBuilder.CreateTable(
                name: "PreferenceClasseOfServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClasseOfServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<uint>(type: "INTEGER", nullable: false),
                    Uuid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceClasseOfServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferenceClasseOfServices_am_class_of_service_ClasseOfServiceId",
                        column: x => x.ClasseOfServiceId,
                        principalSchema: "agile_manager",
                        principalTable: "am_class_of_service",
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
                name: "IX_am_preference_status_category_stct_id",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "stct_id");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceClasseOfServices_ClasseOfServiceId",
                table: "PreferenceClasseOfServices",
                column: "ClasseOfServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceClasseOfServices_ProjectId",
                table: "PreferenceClasseOfServices",
                column: "ProjectId");
        }
    }
}
