using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddToDoProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Body", "IsFeatured", "RepoUrl", "Slug", "Summary", "TechStack", "Title", "Year" },
                values: new object[] { 2, "First pargraph.\n\nSecond paragraph.", false, null, "todo-app", "A simple tast app built with Flutter.", "Flutter", "ToDo app", 2023 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
