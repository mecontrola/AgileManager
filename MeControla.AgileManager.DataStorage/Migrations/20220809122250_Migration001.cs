using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "agile_manager");

            migrationBuilder.CreateTable(
                name: "am_issue_type",
                schema: "agile_manager",
                columns: table => new
                {
                    istp_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    istp_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    istp_key = table.Column<long>(type: "INTEGER", nullable: false),
                    istp_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_type", x => x.istp_id);
                });

            migrationBuilder.CreateTable(
                name: "am_project_category",
                schema: "agile_manager",
                columns: table => new
                {
                    pjct_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pjct_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    pjct_key = table.Column<long>(type: "INTEGER", nullable: false),
                    pjct_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_project_category", x => x.pjct_id);
                });

            migrationBuilder.CreateTable(
                name: "am_quarter",
                schema: "agile_manager",
                columns: table => new
                {
                    qrt_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    qrt_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    qrt_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_quarter", x => x.qrt_id);
                });

            migrationBuilder.CreateTable(
                name: "am_status_category",
                schema: "agile_manager",
                columns: table => new
                {
                    stct_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stct_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    stct_key = table.Column<long>(type: "INTEGER", nullable: false),
                    stct_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_status_category", x => x.stct_id);
                });

            migrationBuilder.CreateTable(
                name: "am_project",
                schema: "agile_manager",
                columns: table => new
                {
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prj_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    prj_key = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prj_project_category_id = table.Column<long>(type: "INTEGER", nullable: false),
                    prj_selected = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_project", x => x.prj_id);
                    table.ForeignKey(
                        name: "FK_am_project_am_project_category_prj_project_category_id",
                        column: x => x.prj_project_category_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project_category",
                        principalColumn: "pjct_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_status",
                schema: "agile_manager",
                columns: table => new
                {
                    stt_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stt_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    stt_key = table.Column<long>(type: "INTEGER", nullable: false),
                    stt_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    stct_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_status", x => x.stt_id);
                    table.ForeignKey(
                        name: "FK_am_status_am_status_category_stct_id",
                        column: x => x.stct_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_status_category",
                        principalColumn: "stct_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_issue",
                schema: "agile_manager",
                columns: table => new
                {
                    iss_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    iss_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    iss_key = table.Column<string>(type: "TEXT", nullable: false),
                    iss_summary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    iss_incident = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    iss_created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    iss_updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    iss_resolved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    iss_link = table.Column<string>(type: "TEXT", nullable: false),
                    prj_id = table.Column<long>(type: "INTEGER", nullable: false),
                    stt_id = table.Column<long>(type: "INTEGER", nullable: false),
                    istp_id = table.Column<long>(type: "INTEGER", nullable: false),
                    iss_custom_field14503 = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue", x => x.iss_id);
                    table.ForeignKey(
                        name: "FK_am_issue_am_issue_type_istp_id",
                        column: x => x.istp_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue_type",
                        principalColumn: "istp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_issue_am_project_prj_id",
                        column: x => x.prj_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_project",
                        principalColumn: "prj_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_issue_am_status_stt_id",
                        column: x => x.stt_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_status",
                        principalColumn: "stt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_issue_epic",
                schema: "agile_manager",
                columns: table => new
                {
                    isep_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isep_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    isep_progress = table.Column<decimal>(type: "TEXT", nullable: false),
                    iss_id = table.Column<long>(type: "INTEGER", nullable: false),
                    qrt_id = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_epic", x => x.isep_id);
                    table.ForeignKey(
                        name: "FK_am_issue_epic_am_issue_iss_id",
                        column: x => x.iss_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_issue_epic_am_quarter_qrt_id",
                        column: x => x.qrt_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_quarter",
                        principalColumn: "qrt_id");
                });

            migrationBuilder.CreateTable(
                name: "am_issue_impediment",
                schema: "agile_manager",
                columns: table => new
                {
                    isim_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isim_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    isim_start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isim_end = table.Column<DateTime>(type: "TEXT", nullable: true),
                    iss_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_impediment", x => x.isim_id);
                    table.ForeignKey(
                        name: "FK_am_issue_impediment_am_issue_iss_id",
                        column: x => x.iss_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "am_issue_status_history",
                schema: "agile_manager",
                columns: table => new
                {
                    ish_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ish_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    ish_date_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isep_id = table.Column<long>(type: "INTEGER", nullable: false),
                    stt_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_status_history", x => x.ish_id);
                    table.ForeignKey(
                        name: "FK_am_issue_status_history_am_issue_isep_id",
                        column: x => x.isep_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_issue_status_history_am_status_stt_id",
                        column: x => x.stt_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_status",
                        principalColumn: "stt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "agile_manager",
                table: "am_project_category",
                columns: new[] { "pjct_id", "pjct_key", "pjct_name", "pjct_uuid" },
                values: new object[] { 1L, 0L, "No Category", new Guid("042b72f2-0848-47a1-bb11-8ed69b0caf7e") });

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

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_istp_id",
                schema: "agile_manager",
                table: "am_issue",
                column: "istp_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_prj_id",
                schema: "agile_manager",
                table: "am_issue",
                column: "prj_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_stt_id",
                schema: "agile_manager",
                table: "am_issue",
                column: "stt_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_epic_iss_id",
                schema: "agile_manager",
                table: "am_issue_epic",
                column: "iss_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_epic_qrt_id",
                schema: "agile_manager",
                table: "am_issue_epic",
                column: "qrt_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_impediment_iss_id",
                schema: "agile_manager",
                table: "am_issue_impediment",
                column: "iss_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_status_history_isep_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "isep_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_status_history_stt_id",
                schema: "agile_manager",
                table: "am_issue_status_history",
                column: "stt_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_project_prj_project_category_id",
                schema: "agile_manager",
                table: "am_project",
                column: "prj_project_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_status_stct_id",
                schema: "agile_manager",
                table: "am_status",
                column: "stct_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "am_issue_epic",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_issue_impediment",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_issue_status_history",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_quarter",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_issue",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_issue_type",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_project",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_status",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_project_category",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_status_category",
                schema: "agile_manager");
        }
    }
}
