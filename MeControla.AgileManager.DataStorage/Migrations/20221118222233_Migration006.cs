using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeControla.AgileManager.DataStorage.Migrations
{
    public partial class Migration006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_am_preference_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_preference_custom_field");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "cfd_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_am_preference_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_preference_custom_field");

            migrationBuilder.CreateIndex(
                name: "IX_am_preference_custom_field_cfd_id",
                schema: "agile_manager",
                table: "am_preference_custom_field",
                column: "cfd_id");
        }
    }
}
