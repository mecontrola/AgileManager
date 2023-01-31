using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "am_customfield",
                schema: "agile_manager",
                columns: table => new
                {
                    cfd_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cfd_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    cfd_key = table.Column<string>(type: "TEXT", nullable: false),
                    cfd_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    cfd_type = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    cfd_custom = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    cfd_active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_customfield", x => x.cfd_id);
                });

            migrationBuilder.CreateTable(
                name: "am_issue_customfield_data",
                schema: "agile_manager",
                columns: table => new
                {
                    isep_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isep_uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    isep_value = table.Column<string>(type: "TEXT", nullable: false),
                    cfd_id = table.Column<long>(type: "INTEGER", nullable: false),
                    iss_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_am_issue_customfield_data", x => x.isep_id);
                    table.ForeignKey(
                        name: "FK_am_issue_customfield_data_am_customfield_cfd_id",
                        column: x => x.cfd_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_customfield",
                        principalColumn: "cfd_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_am_issue_customfield_data_am_issue_iss_id",
                        column: x => x.iss_id,
                        principalSchema: "agile_manager",
                        principalTable: "am_issue",
                        principalColumn: "iss_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_customfield_data_cfd_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data",
                column: "cfd_id");

            migrationBuilder.CreateIndex(
                name: "IX_am_issue_customfield_data_iss_id",
                schema: "agile_manager",
                table: "am_issue_customfield_data",
                column: "iss_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "am_issue_customfield_data",
                schema: "agile_manager");

            migrationBuilder.DropTable(
                name: "am_customfield",
                schema: "agile_manager");
        }
    }
}
