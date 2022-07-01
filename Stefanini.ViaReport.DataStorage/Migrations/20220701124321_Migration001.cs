using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefanini.ViaReport.DataStorage.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProjectCategoryId = table.Column<long>(type: "INTEGER", nullable: false),
                    Selected = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "ProjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StatusCategoryId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_StatusCategories_StatusCategoryId",
                        column: x => x.StatusCategoryId,
                        principalTable: "StatusCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Incident = table.Column<bool>(type: "INTEGER", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Resolved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<long>(type: "INTEGER", nullable: false),
                    IssueTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    CustomField14503 = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CustomField15703 = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_IssueTypes_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueStatusHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IssueId = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStatusHistories_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueStatusHistories_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "Key", "Name", "Uuid" },
                values: new object[] { 1L, 12904L, "Aplicativos", new Guid("15792637-4496-4e0f-8848-e3ee2b077711") });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "Key", "Name", "Uuid" },
                values: new object[] { 2L, 11404L, "Decisão", new Guid("975a10e5-74fa-4529-baf7-c08d79d62c9a") });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "Key", "Name", "Uuid" },
                values: new object[] { 3L, 11104L, "Descoberta", new Guid("b1c8348f-aa66-46fd-97bd-2ffe97d681bb") });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "Key", "Name", "Uuid" },
                values: new object[] { 4L, 12905L, "Fidelização", new Guid("dc5e09d1-610d-4ced-9c06-e014fc2b2beb") });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProjectId",
                table: "Issues",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StatusId",
                table: "Issues",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStatusHistories_IssueId",
                table: "IssueStatusHistories",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStatusHistories_StatusId",
                table: "IssueStatusHistories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_StatusCategoryId",
                table: "Statuses",
                column: "StatusCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueStatusHistories");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "IssueTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropTable(
                name: "StatusCategories");
        }
    }
}
