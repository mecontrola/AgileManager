using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_am_preference_status_category_StatusCategoryId1",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_category_StatusCategoryId1",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "StatusCategoryId1",
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
    }
}
