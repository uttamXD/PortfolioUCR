using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class NewProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Summary" },
                values: new object[] { "A simple task-management app built with Flutter.\n\nIt helped me practise building a useful mobile interface.", "A simple test app built with Flutter." });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Body", "IsFeatured", "LiveUrl", "RepoUrl", "Slug", "Summary", "TechStack", "Title", "Year" },
                values: new object[,]
                {
                    { 3, "A web app for creating PDFs from forms filled in by the user, including forms for government documents.", false, null, null, "PDF Generator", "A web app built with Flutter", "Flutter", "PDF Generator", 2024 },
                    { 4, "I worked on integrating Business Central and Dynamics NAV with a third-party app, so users could create opportunities that eventually became sales orders.", false, null, null, "MAW OTCI Integration", "A integration project to connect NAV and BC to third party app.", "C/AL, AL", "MAW OTCI Integration", 2025 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Summary" },
                values: new object[] { "First pargraph.\n\nSecond paragraph.", "A simple tast app built with Flutter." });
        }
    }
}
