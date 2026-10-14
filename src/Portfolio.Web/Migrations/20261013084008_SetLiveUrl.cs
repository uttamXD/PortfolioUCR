using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class SetLiveUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LiveUrl",
                value: "http://localhost:5076/Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LiveUrl",
                value: null);
        }
    }
}
