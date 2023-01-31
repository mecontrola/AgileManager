using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreferenceClasseOfServices_am_classe_of_service_ClasseOfServiceId",
                table: "PreferenceClasseOfServices");

            migrationBuilder.DropTable(
                name: "am_classe_of_service",
                schema: "agile_manager");

            migrationBuilder.DropColumn(
                name: "iss_custom_field14503",
                schema: "agile_manager",
                table: "am_issue");

            migrationBuilder.CreateTable(
                name: "am_class_of_service",
                schema: "agile_manager",
                columns: table => new
                {
                    cof_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cof_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    cof_key = table.Column<string>(type: "TEXT", nullable: false),
                    cof_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_class_of_service", x => x.cof_id);
                });

            migrationBuilder.CreateTable(
                name: "am_issue_extra_data",
                schema: "agile_manager",
                columns: table => new
                {
                    iss_id = table.Column<long>(type: "INTEGER", nullable: false),
                    ied_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    ied_story_points = table.Column<decimal>(type: "TEXT", nullable: false),
                    ied_impediment = table.Column<bool>(type: "INTEGER", nullable: false),
                    cof_id = table.Column<long>(type: "INTEGER", nullable: true),
                    ied_customer_lead_time = table.Column<decimal>(type: "TEXT", nullable: false),
                    ied_discovery_lead_time = table.Column<decimal>(type: "TEXT", nullable: false),
                    ied_system_lead_time = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_extra_data", x => x.iss_id);
                    table.ForeignKey(
                        name: "FK_am_issue_extra_data_am_class_of_service_cof_id",
                        column: x => x.cof_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_class_of_service",
                        principalColumn: "cof_id");
                    table.ForeignKey(
                        name: "FK_am_issue_extra_data_am_issue_iss_id",
                        column: x => x.iss_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_extra_data_cof_id",
                schema: "agile_manager",
                table: "am_issue_extra_data",
                column: "cof_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_extra_data_iss_id",
                schema: "agile_manager",
                table: "am_issue_extra_data",
                column: "iss_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PreferenceClasseOfServices_am_class_of_service_ClasseOfServiceId",
                table: "PreferenceClasseOfServices",
                column: "ClasseOfServiceId",
                principalSchema: "agile_manager",
                principalTable: "am_class_of_service",
                principalColumn: "cof_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreferenceClasseOfServices_am_class_of_service_ClasseOfServiceId",
                table: "PreferenceClasseOfServices");

            migrationBuilder.DropTable(
                name: "am_issue_extra_data",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_class_of_service",
                schema: "agile_manager");

            migrationBuilder.AddColumn<DateTime>(
                name: "iss_custom_field14503",
                schema: "agile_manager",
                table: "am_issue",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "am_classe_of_service",
                schema: "agile_manager",
                columns: table => new
                {
                    cof_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cof_key = table.Column<string>(type: "TEXT", nullable: false),
                    cof_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cof_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_classe_of_service", x => x.cof_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PreferenceClasseOfServices_am_classe_of_service_ClasseOfServiceId",
                table: "PreferenceClasseOfServices",
                column: "ClasseOfServiceId",
                principalSchema: "agile_manager",
                principalTable: "am_classe_of_service",
                principalColumn: "cof_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
