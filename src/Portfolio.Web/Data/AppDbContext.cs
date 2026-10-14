using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Models;

namespace Portfolio.Web.Data;

// The DbContext is your connection to the database.
// Each DbSet<T> is one table.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Two projects can't share the same slug (like a unique key in the AL).
        modelBuilder.Entity<Project>().HasIndex(p => p.Slug).IsUnique();

        // Starting data, inserted by the first migration.
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Title = "This portfolio",
                Slug = "this-portfolio",
                Summary = "This site you are looking at. My first ASP.NET Core project.",
                Body = "I built this site to learn C# and .NET after working with AL.\n\nIt uses Razor Pages, Entity Framework Core and SQLite.",
                TechStack = "C#, Razor Pages, EF Core, SQLite",
                Year = 2026,
                IsFeatured = true,
                LiveUrl = "http://localhost:5076/Projects"
            },
            new Project
            {
                Id = 2,
                Title = "ToDo app",
                Slug = "todo-app",
                Summary = "A simple test app built with Flutter.",
                Body = "A simple task-management app built with Flutter.\n\nIt helped me practise building a useful mobile interface.",
                TechStack = "Flutter",
                Year = 2023,
                IsFeatured = false
            },
            new Project
            {
                Id = 3,
                Title = "PDF Generator",
                Slug = "pdf-generator",
                Summary = "A web app built with Flutter",
                Body = "A web app for creating PDFs from forms filled in by the user, including forms for government documents.",
                TechStack = "Flutter",
                Year = 2024,
                IsFeatured = false
            },
            new Project
            {
                Id = 4,
                Title = "MAW OTCI Integration",
                Slug = "maw-otci-integration",
                Summary = "A integration project to connect NAV and BC to third party app.",
                Body = "I worked on integrating Business Central and Dynamics NAV with a third-party app, so users could create opportunities that eventually became sales orders.",
                TechStack = "C/AL, AL",
                Year = 2025,
                IsFeatured = false
            }
        );
    }
}