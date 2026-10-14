using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddLiveUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LiveUrl",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "LiveUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "LiveUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiveUrl",
                table: "Projects");
        }
    }
}
