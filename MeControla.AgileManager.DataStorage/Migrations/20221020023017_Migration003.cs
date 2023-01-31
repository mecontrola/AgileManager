using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_customfield_data_am_customfield_cfd_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data");

            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_status_history_am_issue_isep_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_status_history_am_status_stt_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_am_customfield",
                schema: "agile_manager",
                table: "am_customfield");

            migrationBuilder.DeleteData(
                schema: "agile_manager",
                table: "am_project_category",
                keyColumn: "pjct_id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "agile_manager",
                table: "am_project_category",
                keyColumn: "pjct_id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "agile_manager",
                table: "am_project_category",
                keyColumn: "pjct_id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "agile_manager",
                table: "am_project_category",
                keyColumn: "pjct_id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "cfd_active",
                schema: "agile_manager",
                table: "am_customfield");

            migrationBuilder.RenameTable(
                name: "am_customfield",
                schema: "agile_manager",
                newName: "am_custom_field",
                newSchema: "agile_manager");

            migrationBuilder.RenameColumn(
                name: "isep_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "iss_id");

            migrationBuilder.RenameColumn(
                name: "stt_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "ish_to_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_am_issue_status_history_stt_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "IX_am_issue_status_history_ish_to_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_am_issue_status_history_isep_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "IX_am_issue_status_history_iss_id");

            migrationBuilder.AddColumn<long>(
                name: "ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_am_custom_field",
                schema: "agile_manager",
                table: "am_custom_field",
                column: "cfd_id");

            migrationBuilder.CreateTable(
                name: "am_classe_of_service",
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
                    table.PrimaryKey("PK_am_classe_of_service", x => x.cof_id);
                });

            migrationBuilder.CreateTable(
                name: "am_period",
                schema: "agile_manager",
                columns: table => new
                {
                    prd_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prd_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    prd_key = table.Column<string>(type: "TEXT", nullable: false),
                    prd_type = table.Column<uint>(type: "INTEGER", nullable: false),
                    prd_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prd_initial = table.Column<DateTime>(type: "TEXT", nullable: false),
                    prd_final = table.Column<DateTime>(type: "TEXT", nullable: true),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_period", x => x.prd_id);
                    table.ForeignKey(
                        name: "FK_am_period_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_preference_custom_field",
                schema: "agile_manager",
                columns: table => new
                {
                    pcf_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pcf_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    pcf_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    pcf_type = table.Column<uint>(type: "INTEGER", nullable: false),
                    cfd_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_preference_custom_field", x => x.pcf_id);
                    table.ForeignKey(
                        name: "FK_am_preference_custom_field_am_custom_field_cfd_id",
                        column: x => x.cfd_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_custom_field",
                        principalColumn: "cfd_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_preference_custom_field_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_preference_issue_type",
                schema: "agile_manager",
                columns: table => new
                {
                    pit_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pit_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    pit_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    pit_type = table.Column<uint>(type: "INTEGER", nullable: false),
                    istp_id = table.Column<long>(type: "INTEGER", nullable: true),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_preference_issue_type", x => x.pit_id);
                    table.ForeignKey(
                        name: "FK_am_preference_issue_type_am_issue_type_istp_id",
                        column: x => x.istp_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue_type",
                        principalColumn: "istp_id");
                    table.ForeignKey(
                        name: "FK_am_preference_issue_type_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_preference_status",
                schema: "agile_manager",
                columns: table => new
                {
                    psc_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    psc_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    psc_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    psc_order = table.Column<uint>(type: "INTEGER", nullable: false, defaultValue: 0u),
                    psc_progress = table.Column<decimal>(type: "TEXT", nullable: false, defaultValue: 0m),
                    stt_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_preference_status", x => x.psc_id);
                    table.ForeignKey(
                        name: "FK_am_preference_status_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_preference_status_am_status_stt_id",
                        column: x => x.stt_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_status",
                        principalColumn: "stt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_preference_status_category",
                schema: "agile_manager",
                columns: table => new
                {
                    psc_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    psc_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    psc_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    psc_type = table.Column<uint>(type: "INTEGER", nullable: false),
                    stct_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_preference_status_category", x => x.psc_id);
                    table.ForeignKey(
                        name: "FK_am_preference_status_category_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_preference_status_category_am_status_category_stct_id",
                        column: x => x.stct_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_status_category",
                        principalColumn: "stct_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_status_history_ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "ish_from_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_period_prj_id",
                schema: "agile_manager",
                table: "am_period",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "cfd_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_custom_field_prj_id",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_issue_type_istp_id",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "istp_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_issue_type_prj_id",
                schema: "agile_manager",
                table: "am_preference_issue_type",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_prj_id",
                schema: "agile_manager",
                table: "am_preference_status",
                column: "prj_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_stt_id",
                schema: "agile_manager",
                table: "am_preference_status",
                column: "stt_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_category_prj_id",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_status_category_stct_id",
                schema: "agile_manager",
                table: "am_preference_status_category",
                column: "stct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_customfield_data_am_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data",
                column: "cfd_id",
                principalSchema: "agile_manager",
                principalTable: "am_custom_field",
                principalColumn: "cfd_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_status_history_am_issue_iss_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "iss_id",
                principalSchema: "agile_manager",
                principalTable: "am_issue",
                principalColumn: "iss_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_status_history_am_status_ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "ish_from_status_id",
                principalSchema: "agile_manager",
                principalTable: "am_status",
                principalColumn: "stt_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_status_history_am_status_ish_to_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "ish_to_status_id",
                principalSchema: "agile_manager",
                principalTable: "am_status",
                principalColumn: "stt_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_customfield_data_am_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data");

            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_status_history_am_issue_iss_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_status_history_am_status_ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_am_issue_status_history_am_status_ish_to_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropTable(
                name: "am_classe_of_service",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_period",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_preference_custom_field",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_preference_issue_type",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_preference_status",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_preference_status_category",
                schema: "agile_manager");

            migrationBuilder.DropIndex(
                name: "IX_am_issue_status_history_ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_am_custom_field",
                schema: "agile_manager",
                table: "am_custom_field");

            migrationBuilder.DropColumn(
                name: "ish_from_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history");

            migrationBuilder.RenameTable(
                name: "am_custom_field",
                schema: "agile_manager",
                newName: "am_customfield",
                newSchema: "agile_manager");

            migrationBuilder.RenameColumn(
                name: "iss_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "isep_id");

            migrationBuilder.RenameColumn(
                name: "ish_to_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "stt_id");

            migrationBuilder.RenameIndex(
                name: "IX_am_issue_status_history_iss_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "IX_am_issue_status_history_isep_id");

            migrationBuilder.RenameIndex(
                name: "IX_am_issue_status_history_ish_to_status_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                newName: "IX_am_issue_status_history_stt_id");

            migrationBuilder.AddColumn<bool>(
                name: "cfd_active",
                schema: "agile_manager",
                table: "am_customfield",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_am_customfield",
                schema: "agile_manager",
                table: "am_customfield",
                column: "cfd_id");

            migrationBuilder.InsertData(
                schema: "agile_manager",
                table: "am_project_category",
                columns: new[] { "pjct_id", "pjct_key", "pjct_name", "pjct_uuid" },
                values: new object[] { 2L, 12904L, "Aplicativos", new Guid("15792637-4496-4e0f-8848-e3ee2b077711") });

            migrationBuilder.InsertData(
                schema: "agile_manager",
                table: "am_project_category",
                columns: new[] { "pjct_id", "pjct_key", "pjct_name", "pjct_uuid" },
                values: new object[] { 3L, 11404L, "Decisão", new Guid("975a10e5-74fa-4529-baf7-c08d79d62c9a") });

            migrationBuilder.InsertData(
                schema: "agile_manager",
                table: "am_project_category",
                columns: new[] { "pjct_id", "pjct_key", "pjct_name", "pjct_uuid" },
                values: new object[] { 4L, 11104L, "Descoberta", new Guid("b1c8348f-aa66-46fd-97bd-2ffe97d681bb") });

            migrationBuilder.InsertData(
                schema: "agile_manager",
                table: "am_project_category",
                columns: new[] { "pjct_id", "pjct_key", "pjct_name", "pjct_uuid" },
                values: new object[] { 5L, 12905L, "Fidelização", new Guid("dc5e09d1-610d-4ced-9c06-e014fc2b2beb") });

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_customfield_data_am_customfield_cfd_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data",
                column: "cfd_id",
                principalSchema: "agile_manager",
                principalTable: "am_customfield",
                principalColumn: "cfd_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_status_history_am_issue_isep_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "isep_id",
                principalSchema: "agile_manager",
                principalTable: "am_issue",
                principalColumn: "iss_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_am_issue_status_history_am_status_stt_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "stt_id",
                principalSchema: "agile_manager",
                principalTable: "am_status",
                principalColumn: "stt_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
