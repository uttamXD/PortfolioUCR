using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixSlugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slug",
                value: "pdf-generator");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Slug",
                value: "maw-otci-integration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slug",
                value: "PDF Generator");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Slug",
                value: "MAW OTCI Integration");
        }
    }
}
